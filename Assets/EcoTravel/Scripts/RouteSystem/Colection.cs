using System.Collections.Generic;

namespace routeSystem
{
    [System.Serializable]
    public class Colection
    {
        string key;
        ScreenInfo screenInfo;
        List<int> routeIDs;

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
