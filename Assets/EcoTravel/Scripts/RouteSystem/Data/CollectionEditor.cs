using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "CollectionEditor", menuName = "RouteSystem/CollectionEditor", order = 1)]
    public class CollectionEditor : ScriptableObject
    {
        public string key;
        public List<int> routeIDs;

        public string _name;
        public string description;
        public List<Photo> photos;
        [Space]
        [Space]
        public int photoIndex;
        public string _url;
        public string _path;

        public void GetCollection()
        {
            if (RouteStore.ConstainsCollection(key))
            {   
                Collection collection = RouteStore.Collections[key];

                routeIDs = collection.routeIDs;

                _name = collection.screenInfo._name;
                description = collection.screenInfo.description;
                photos = collection.screenInfo.photos;
                Debug.Log("Get Collection successfully");

            }
            else Debug.Log("does not exist Collection key");
        }
        public bool CreateCollection()
        {
            if (RouteStore.ConstainsCollection(key)) { 
                Debug.Log("Collection key occupant");
                return false;
            }
            RouteStore.Collections.Add(key, new Collection(key));
            Debug.Log("Create New Collection");
            return true;
        }
        public void SetCollection()
        {
            if (RouteStore.ConstainsCollection(key))
            {
                Collection collection = new Collection(key);

                collection.routeIDs = routeIDs;

                collection.screenInfo._name = _name;
                collection.screenInfo.description = description;
                collection.screenInfo.photos = photos;

                RouteStore.Collections[key] = collection;
                Debug.Log("Set Collection successfully");
            }
            else
            {
                Debug.Log("does not exist Collection key");
                if(!CreateCollection()) return;
                SetCollection();
            }



        }
        public void GetPhoto()
        {
            if (RouteStore.ConstainsCollection(key))
            {
             
                photos = RouteStore.Collections[key].screenInfo.photos;
                if (photoIndex < photos.Count)
                {
                     _url = photos[photoIndex]._url;
                     _path = photos[photoIndex]._path;
                    Debug.Log("Get Photo successfully");
                }
                else Debug.Log("does not exist Photo ID");     
            }
            else Debug.Log("does not exist Collection key");
        }
        public void SetPhoto()
        {
            if (RouteStore.Collections[key].screenInfo.ContainsPhotoIndex(photoIndex))
            {
                Photo photo = new Photo(_path, _url);
                RouteStore.Collections[key].screenInfo.photos[photoIndex] = photo;
                Debug.Log("Set Photo successfully");
            }
            else
            {
                Debug.Log("does not exist Photo ID");
                photoIndex = CreatePhoto();
                SetPhoto();
            }
        }
        public int CreatePhoto()
        {
            int emptyIndex = RouteStore.Collections[key].screenInfo.EmptyPhotoIndex();
            RouteStore.Collections[key].screenInfo.photos.Add(new Photo());
            Debug.Log("Create New Photo");
            return emptyIndex;
        }

    }
}
