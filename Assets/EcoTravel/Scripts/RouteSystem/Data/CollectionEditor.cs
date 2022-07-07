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
            collection = RouteStore.GetCollection(key);
        }
        
        public void SetCollection()
        {
            RouteStore.SetCollection(collection);
        }       
    }
}
