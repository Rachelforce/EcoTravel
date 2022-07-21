using GoToApps.Serialization; 
using UnityEngine;
using routeSystem;
using System.IO;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Custom.UI.System;
using PhotoSystem;

namespace routeSystem
{

    public class StoreUpdater : MonoBehaviour
    {
        [SerializeField] PhotoStore photoStore;
        [SerializeField] MarkerMapManager markerMapManager;
        [SerializeField] string path;
        [SerializeField] string fileName;
        [SerializeField][TextArea] string startJsone;
        bool roadLoad = false;
        bool collectionLoad = false;
        bool photoLoad = false;

        private void Awake()
        {
            path = Path.Combine(Application.dataPath, fileName);
            LoadFromWeb();

            

        }
        private void OnDestroy()
        {
            SaveToFile();
        }


        private bool LoadFromFile()
        {
            this.path = Path.Combine(Application.dataPath, this.fileName);

            if (File.Exists(this.path))
            {

                RouteStoreSerialize routeStoreSerialize = JsonSerializer.Load<RouteStoreSerialize>(this.path);
                routeStoreSerialize.OnAfterDeserialize();
                return true;
            }
            else { return false; }
        }
        private bool LoadFromString()
        {
            if (startJsone != null)
            {
                RouteStoreSerialize routeStoreSerialize = JsonSerializer.LoadFromString<RouteStoreSerialize>(startJsone);
                routeStoreSerialize.OnAfterDeserialize();
                return true;
            }
            else return false; 
        }
        private bool LoadFromWeb()
        {
            IEnumerator routeCoroutine = WebRequestToLoad(GetRequestTipe.Route);
            IEnumerator collectionCoroutine = WebRequestToLoad(GetRequestTipe.Collection);
            StartCoroutine(routeCoroutine);
            StartCoroutine(collectionCoroutine);
            StartCoroutine("LoadStartCollection");
            return true;
        }
        private void SaveToFile()
        {
            RouteStoreSerialize testSerialize = new RouteStoreSerialize(1);
            JsonSerializer.Save(this.path, testSerialize);
        }

         

        enum GetRequestTipe { Route, Collection }
        private IEnumerator WebRequestToLoad(GetRequestTipe requestType, int id = -1)
        {
            string request = requestType.ToString();
            if (id != -1) request += "/" + id.ToString();
            using (UnityWebRequest webRequest = UnityWebRequest.Get(WebConfig.url + request))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();
                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(webRequest.error);
                }
                else
                {
                    if (requestType == GetRequestTipe.Route)
                    {
                        if (id == -1) PharseRouteList(webRequest.downloadHandler.text);
                        else PharseRoute(webRequest.downloadHandler.text);
                        Debug.Log("Load Route done");
                    }
                    else
                    {
                        if (id == -1) PharseCollectionList(webRequest.downloadHandler.text);
                        else PharseCollection(webRequest.downloadHandler.text);
                        Debug.Log("Load Collection done");
                    }
                }
            }
        }

        private void PharseRouteList(string content)
        {
            List<Route> routeList = JsonSerializer.LoadFromString<List<Route>>(content);
            foreach (Route route in routeList)
            {
                RouteStore.SetRout(route);
                if (!route.InitializePhotoList()) continue;
                foreach (Photo photo in route.photos)
                {
                    photoStore.allPhoto.Add(photo);
                }               
            }
            Debug.Log("PharseRouteList done");
            roadLoad = true;
        }
        private void PharseRoute(string content)
        {
            Route route = JsonSerializer.LoadFromString<Route>(content);
            RouteStore.SetRout(route);
        }

        private void PharseCollectionList(string content)
        {
            List<Collection> collections = JsonSerializer.LoadFromString<List<Collection>>(content);
            foreach (Collection collection in collections)
            {
                if(!collection.InitializePhotoList()) continue;
                foreach (Photo photo in collection.photos)
                {
                    photoStore.allPhoto.Add(photo);
                }
                
                RouteStore.SetCollection(collection);     
            }
            Debug.Log("PharseCollectionList done");
            collectionLoad = true;
        }
        private void PharseCollection(string content)
        {
            Collection collection = JsonSerializer.LoadFromString<Collection>(content);
            RouteStore.SetCollection(collection);
        }


        private IEnumerator LoadStartCollection()
        {
            yield return collectionLoad && roadLoad;
            photoStore.SetTextureToAllPhoto(ref photoLoad);
            yield return collectionLoad && roadLoad && photoLoad;
            markerMapManager.LoadColectionMarkers(3);
            Debug.Log("Set start collection done");
        }
    }
}
