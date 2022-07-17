using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "CollectionEditor", menuName = "RouteSystem/CollectionEditor", order = 1)]
    public class CollectionEditor : ScriptableObject
    {
        public int ID;

        public Collection collection;
        
        public void GetCollection()
        {
            collection = RouteStore.GetCollection(ID);
        }
        
        public void SetCollection()
        {
            RouteStore.SetCollection(collection);
        }       
    }
}

