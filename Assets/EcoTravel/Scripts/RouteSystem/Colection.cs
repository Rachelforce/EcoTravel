using System.Collections.Generic;
using System;

namespace routeSystem
{
    [System.Serializable]
    public class Colection
    {
        [NonSerialized] string key;
        [NonSerialized] ScreenInfo screenInfo;
        [NonSerialized] List<int> routeIDs;


        public List<Route> GetRoutes()
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
