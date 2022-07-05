using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "CollectionEditor", menuName = "RouteSystem/CollectionEditor", order = 1)]
    public class CollectionEditor : ScriptableObject
    {
        public string key;

        public Collection collection;

        public void GetCollection()
        {
            if (RouteStore.ConstainsCollection(key))
            {   
                collection = RouteStore.Collections[key];              
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
    }
}
