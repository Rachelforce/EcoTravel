using GoToApps.Serialization; 
using UnityEngine;
using routeSystem;
using System.IO;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
namespace routeSystem
{

    public class StoreUpdater : MonoBehaviour
    {
        [SerializeField] string path;
        [SerializeField] string fileName;
        [SerializeField][TextArea] string startJsone;
        private void Awake()
        {
            path = Path.Combine(Application.dataPath, fileName);

            IEnumerator routeCoroutine = WebRequestToLoad(GetRequestTipe.Route);
            IEnumerator collectionCoroutine = WebRequestToLoad(GetRequestTipe.Collection);
            StartCoroutine(routeCoroutine);
            StartCoroutine(collectionCoroutine);
        }
        private void OnDestroy()
        {
            RouteStoreSerialize testSerialize = new RouteStoreSerialize(1);
            JsonSerializer.Save(this.path, testSerialize);
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
            else { return false; }
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
                        Debug.Log("LoadRoute");
                    }
                    else
                    {
                        if (id == -1) PharseCollectionList(webRequest.downloadHandler.text);
                        else PharseCollection(webRequest.downloadHandler.text);
                        Debug.Log("LoadCollection");
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
            }
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
                Debug.Log(collection.key);
                RouteStore.SetCollection(collection);

            }
        }
        private void PharseCollection(string content)
        {
            Collection collection = JsonSerializer.LoadFromString<Collection>(content);
            RouteStore.SetCollection(collection);
        }
        

    }
}
