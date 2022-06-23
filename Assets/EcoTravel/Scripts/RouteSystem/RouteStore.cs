using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    public class RouteStore : MonoBehaviour, ISerializationCallbackReceiver
    {
        static public Dictionary<int, Route> RoutesData { get; private set; }
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



        #region ISerialize
        [SerializeField]   List<int>rotesDataKey;
        [SerializeField]   List<Route> routesDataValue;
        [SerializeField]   List<string> colectionsDataKey;
        [SerializeField]   List<Colection> colectionsDataValue;
        public void OnBeforeSerialize()
        {
            try
            {
                rotesDataKey = new List<int>(RoutesData.Keys);
                routesDataValue = new List<Route>(RoutesData.Values);
                colectionsDataKey = new List<string>(Colections.Keys);
                colectionsDataValue = new List<Colection>(Colections.Values);
            }
            catch { return; }
        }

        public void OnAfterDeserialize()
        {
            if(rotesDataKey.Count != routesDataValue.Count)
            throw new System.IndexOutOfRangeException("Size for key and value");
            if (colectionsDataKey.Count != colectionsDataValue.Count)
                throw new System.IndexOutOfRangeException("Size for key and value");
            RoutesData = new Dictionary<int, Route>();
            for (int i = 0; i < rotesDataKey.Count; i++)
            {
                RoutesData.Add(rotesDataKey[i], routesDataValue[i]);
            }

            Colections = new Dictionary<string, Colection>();
            for (int i = 0; i < colectionsDataKey.Count; i++)
            {
                Colections.Add(colectionsDataKey[i], colectionsDataValue[i]);
            }
        }
        #endregion ISerialize
    }
}
