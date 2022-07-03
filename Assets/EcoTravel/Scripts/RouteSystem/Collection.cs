using System.Collections.Generic;
using System;

namespace routeSystem
{
    [System.Serializable]
    public class Collection
    {
        public string key;
        public ScreenInfo screenInfo;
        public List<int> routeIDs;

        public Collection(string key) { this.key = key; screenInfo = new ScreenInfo(); routeIDs = new List<int>(); }
        public List<Route> GetFromStore()
        {
            List<Route> colectionRoutes = new List<Route>();
            foreach(int elevent in routeIDs)
            {
                colectionRoutes.Add(RouteStore.RoutesData[elevent]);
            }
            return colectionRoutes;
        }
    }
}
