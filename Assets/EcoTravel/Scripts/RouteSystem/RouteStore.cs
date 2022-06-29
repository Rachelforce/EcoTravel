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
        static public List<int> RouteID;
        static public Dictionary<string, Colection> Colections;
        

       


        public static bool ContainsRoute(int i)
        {
            return RoutesData.ContainsKey(i);
        }
        public static int EmptyRouteIndex(int Index = -1)
        {
            if (Index == -1)
                Index = RouteID[RouteID.Count - 1] + 1;
    
            if (!ContainsRoute(Index))
                return Index;
            else EmptyRouteIndex(Index + 1);
            return -1;
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
                //if (colectionsDataKey)
                  //  throw new System.IndexOutOfRangeException("Size for key and value");
                RouteStore.RoutesData = new Dictionary<int, Route>();
                for (int i = 0; i < rotesDataKey.Count; i++)
                {
                    RouteStore.RoutesData.Add(rotesDataKey[i], routesDataValue[i]);
                }
                /*
                RouteStore.Colections = new Dictionary<string, Colection>();
                for (int i = 0; i < colectionsDataKey.Count; i++)
                {
                    RouteStore.Colections.Add(colectionsDataKey[i], colectionsDataValue[i]);
                }
                */
            }
            else Debug.Log("Dont Work");
        }

    }
}
