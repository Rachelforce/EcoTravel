using System.Collections.Generic;
using System;
using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    public class Collection: ScreenInfo
    {
        public string key;
        public List<int> routesID;

        public Collection(int id) { this.ID = id; routesID = new List<int>(); }

        public List<Route> GetFromStore()
        {
            List<Route> colectionRoutes = new List<Route>();
            if (routesID == null) {
                Debug.Log("routesID is empty");
                return colectionRoutes; }
            foreach(int elevent in routesID)
            {
                colectionRoutes.Add(RouteStore.RoutesData[elevent]);
            }
            return colectionRoutes;
        }
    }
}
