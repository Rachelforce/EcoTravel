using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "RouteEditor", menuName = "RouteSystem/RouteEditor", order = 1)]
    public class RouteEditor : ScriptableObject
    {
        public int ID;

        public Route route;

        public void GetRout()
        {
            if (RouteStore.ContainsRoute(ID))
            {
                route = RouteStore.RoutesData[ID];

                
                Debug.Log("Get Route successfully");
            }
            else Debug.Log("does not exist Route ID");

        }
        private int CreateRoute()
        {
            int emptyIndex = RouteStore.EmptyRouteIndex();
            RouteStore.RoutesData.Add(emptyIndex, new Route());
            Debug.Log("Create New Route");
            return emptyIndex;
        }
        public void SetRout()
        {
            
            if (!RouteStore.ContainsRoute(ID))
            {
                Debug.Log("does not exist Route ID");
                ID = CreateRoute();
                
            }
            RouteStore.RoutesData[ID] = route;
            Debug.Log("Set Route successfully");
        }


    }
}
