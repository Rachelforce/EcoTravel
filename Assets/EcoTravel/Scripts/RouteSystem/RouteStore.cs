using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace routeSystem
{
    
    public class RouteStore 
    {
        static public Dictionary<int, Route> RoutesData = new Dictionary<int, Route>();
        static public List<int> RouteID;
        static public Dictionary<string, Collection> Collections;

       
        public static Route GetRoute(int id)
            {
            if (ContainsRoute(id))
            {
                Debug.Log("Get Route successfully");
                return RouteStore.RoutesData[id]; 
            }
            else Debug.Log("does not exist Route ID");
            return null;
        }
        public static int SetRout(Route route)
        {
            if (!ContainsRoute(route.ID))
            {
                Debug.Log("does not exist Route ID");
                route.ID = CreateRoute();
            }
            RoutesData[route.ID] = route;
            Debug.Log("Set Route successfully");
            return route.ID;      
        }
        public static void RemoveRoute(int id)
        {
            if (ContainsRoute(id))
            {               
                RoutesData.Remove(id);
                RouteID = new List<int>(RoutesData.Keys);
                Debug.Log("Remove Route successfully");
            }
            else Debug.Log("does not exist Route ID"); 
        }

        public static Collection GetCollection(string key)
        {
            if (ConstainsCollection(key))
            {
                Debug.Log("Get Collection successfully");
                return Collections[key];
            }
            else Debug.Log("does not exist Collection key");
            return null;
        }
        public static string SetCollection(Collection collection)
        {
            if (ConstainsCollection(collection.key))
            {

                Collections[collection.key] = collection;
                Debug.Log("Set Collection successfully");
                return collection.key;
            }
            else
            {
                Debug.Log("does not exist Collection key");
                if (!CreateCollection(collection.key)) return null;
                SetCollection(collection);
            }
            return collection.key;
        }
        public static void RemoveCollection(string key)
        {
            if (ConstainsCollection(key))
            {
                Collections.Remove(key);
                Debug.Log("Remove Collection successfully");
            }
            else Debug.Log("does not exist Collection key");
        }
        

        public static int CreateRoute()
        {
            int emptyIndex = EmptyRouteIndex();
            RoutesData.Add(emptyIndex, new Route());
            Debug.Log("Create New Route");
            return emptyIndex;
        }
        public static bool ContainsRoute(int i)
        {
            try
            {
                return RoutesData.ContainsKey(i);
            }
            catch { return false; }
        }
        public static int EmptyRouteIndex(int Index = -1)
        {
            RouteID = new List<int>(RouteStore.RoutesData.Keys);
            if (Index == -1)
                if (RoutesData.Count == 0) Index = 0;
                else
                if (RouteID.Count == 1) Index = 1;
                else
                Index = RouteID[RouteID.Count - 1] + 1;
    
            if (!ContainsRoute(Index))
                return Index;
            else EmptyRouteIndex(Index + 1);
            return -1;
        }
        public static bool CreateCollection(string key)
        {
            if (ConstainsCollection(key))
            {
                Debug.Log("Collection key occupant");
                return false;
            }
            Collections.Add(key, new Collection(key));
            Debug.Log("Create New Collection");
            return true;
        }
        public static bool ConstainsCollection(string key)

        {
            try
            {
                return Collections.ContainsKey(key);
            }
            catch { return false; }
        }


        
    }

    [System.Serializable]
    public class RouteStoreSerialize: ISerializationCallbackReceiver
    {
        
        public List<int> rotesDataKey;
        public List<Route> routesDataValue;
        public List<string> collectionsDataKey;
        public List<Collection> collectionsDataValue;
        public RouteStoreSerialize()
        {

        }
        public RouteStoreSerialize(int i)
        {
            OnBeforeSerialize();
        }
        public void OnBeforeSerialize()
        {
            try
            {
                rotesDataKey = new List<int>(RouteStore.RoutesData.Keys);
                routesDataValue = new List<Route>(RouteStore.RoutesData.Values);
                collectionsDataKey = new List<string>(RouteStore.Collections.Keys);
                collectionsDataValue = new List<Collection>(RouteStore.Collections.Values);
            }
            catch { return; }
            
        }

        public void OnAfterDeserialize()
        {
            RouteStore.Collections = new Dictionary<string, Collection>();
            RouteStore.RoutesData = new Dictionary<int, Route>();
            if (rotesDataKey != null)
            {
                if (rotesDataKey.Count != routesDataValue.Count)
                    throw new System.IndexOutOfRangeException("Size for key and value");
                if (collectionsDataKey.Count != collectionsDataValue.Count)
                    throw new System.IndexOutOfRangeException("Size for key and value");

                for (int i = 0; i < rotesDataKey.Count; i++)
                {
                    RouteStore.RoutesData.Add(rotesDataKey[i], routesDataValue[i]);
                }
                for (int i = 0; i < collectionsDataKey.Count; i++)
                {
                    RouteStore.Collections.Add(collectionsDataKey[i], collectionsDataValue[i]);
                }
                
            }
            else Debug.Log("Dont Work");
        }

    }
}
