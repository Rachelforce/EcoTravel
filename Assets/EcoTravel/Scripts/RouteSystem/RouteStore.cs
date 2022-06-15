using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    public class RouteStore : MonoBehaviour
    {
        static public Dictionary<int, Route> RoutesData { get; private set; }

        public static int SetRoute(int index, Route route)
        {
            if (RoutesData == null)
            {
                RoutesData = new Dictionary<int, Route>();
                index = 0;
                SetRoute(index, route);
                return index;
            }
            else if (RoutesData.ContainsKey(index)) SetRoute(index + 1, route);
            else { 
                route.ID = index;
                RoutesData[index] = route; 
                }
            return index;
        }
        public static bool SetPoint( ref int routeID, ref int pointID, Point point)
        {
            if (!RoutesData.ContainsKey(routeID)) routeID = SetRoute(routeID, new Route());
            else if (RoutesData[routeID].pointList.Count > pointID)
                pointID = RoutesData[routeID].pointList.Count;
            else if (RoutesData[routeID].pointList.Count < pointID)
            {
                RoutesData[routeID].pointList[pointID] = point;
                return true;
            }
            RoutesData[routeID].pointList.Add(point);
            return true;

        }
        public static bool SetRoad(ref int routeID, ref int roadID, Road road)
        {
            if (!RoutesData.ContainsKey(routeID)) routeID = SetRoute(routeID, new Route());
            else if (RoutesData[routeID].roadList.Count > roadID)
                roadID = RoutesData[routeID].roadList.Count;
            else if (RoutesData[routeID].roadList.Count < roadID)
            {
                RoutesData[routeID].roadList[roadID] = road;
                return true;
            }
            RoutesData[routeID].roadList.Add(road);
            return true;

        }

    }
}
