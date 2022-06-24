using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace routeSystem
{
    
    public class RouteStore 
    {
        static public Dictionary<int, Route> RoutesData;
        static public Dictionary<string, Colection> Colections;

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

    [System.Serializable]
    public class RouteStoreSerialize: ISerializationCallbackReceiver
    {
        
        public List<int> rotesDataKey;
        public List<Route> routesDataValue;
        public List<string> colectionsDataKey;
        public List<Colection> colectionsDataValue;
        public RouteStoreSerialize()
        {

        }
        public RouteStoreSerialize(int i)
        {
            OnBeforeSerialize();
        }
        public void OnBeforeSerialize()
        {
            Debug.Log("IHre");
            rotesDataKey = new List<int>(RouteStore.RoutesData.Keys);
            routesDataValue = new List<Route>(RouteStore.RoutesData.Values);
            //colectionsDataKey = new List<string>(RouteStore.Colections.Keys);
            //colectionsDataValue = new List<Colection>(RouteStore.Colections.Values);
            
        }

        public void OnAfterDeserialize()
        {
            if (rotesDataKey != null)
            {
                if (rotesDataKey.Count != routesDataValue.Count)
                    throw new System.IndexOutOfRangeException("Size for key and value");
                if (colectionsDataKey)
                    throw new System.IndexOutOfRangeException("Size for key and value");
                RouteStore.RoutesData = new Dictionary<int, Route>();
                for (int i = 0; i < rotesDataKey.Count; i++)
                {
                    RouteStore.RoutesData.Add(rotesDataKey[i], routesDataValue[i]);
                }

                RouteStore.Colections = new Dictionary<string, Colection>();
                for (int i = 0; i < colectionsDataKey.Count; i++)
                {
                    RouteStore.Colections.Add(colectionsDataKey[i], colectionsDataValue[i]);
                }
            }
            else Debug.Log("Dont Work");
        }

    }
}
