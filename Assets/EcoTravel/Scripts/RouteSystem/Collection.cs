using System.Collections.Generic;
using System;

namespace routeSystem
{
    [System.Serializable]
    public class Collection: ScreenInfo
    {
        public string key;
        public List<int> routesID;

        public Collection(string key) { this.key = key; routesID = new List<int>(); }

        public List<Route> GetFromStore()
        {
            List<Route> colectionRoutes = new List<Route>();
            foreach(int elevent in routesID)
            {
                colectionRoutes.Add(RouteStore.RoutesData[elevent]);
            }
            return colectionRoutes;
        }
    }
}
