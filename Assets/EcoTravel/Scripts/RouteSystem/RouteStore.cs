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
        //static public List<int> RouteID;
        static public Dictionary<int, Collection> Collections = new Dictionary<int, Collection>();

       
        public static Route GetRoute(int id)
            {
            if (RoutesData.ContainsKey(id))
            {
                Debug.Log("Get Route successfully");
                return RouteStore.RoutesData[id]; 
            }
            else Debug.Log("does not exist Route ID");
            return null;
        }
        public static int SetRout(Route route)
        {
            if (!RoutesData.ContainsKey(route.ID))
            {
                Debug.Log("does not exist Route ID");
                CreateRoute(route);
                return route.ID;
            }
            else
            {
                RoutesData[route.ID] = route;
                Debug.Log("Set Route successfully");
                return route.ID;
            }
        }
        public static void RemoveRoute(int id)
        {
            if (RoutesData.ContainsKey(id))
            {               
                RoutesData.Remove(id);
                //RouteID = new List<int>(RoutesData.Keys);
                Debug.Log("Remove Route successfully");
            }
            else Debug.Log("does not exist Route ID"); 
        }
        private static void CreateRoute(Route route)
        {
            RoutesData.Add(route.ID, route);
            Debug.Log("Create New Route");
        }
        /*
        public static int EmptyRouteIndex(int Index = -1)
        {
            RouteID = new List<int>(RouteStore.RoutesData.Keys);
            if (Index == -1)
                if (RoutesData.Count == 0) Index = 0;
                else
                if (RouteID.Count == 1) Index = 1;
                else
                Index = RouteID[RouteID.Count - 1] + 1;
    
            if (!RoutesData.ContainsKey(Index))
                return Index;
            else EmptyRouteIndex(Index + 1);
            return -1;
        }
        */

        public static Collection GetCollection(int id)
        {
            if (Collections.ContainsKey(id))
            {
                Debug.Log("Get Collection successfully");
                return Collections[id];
            }
            else Debug.Log("does not exist Collection id");
            return null;
        }
        public static int SetCollection(Collection collection)
        {
            if (Collections.ContainsKey(collection.ID))
            {

                Collections[collection.ID] = collection;
                Debug.Log("Set Collection successfully");
                return collection.ID;
            }
            else
            {
                Debug.Log("does not exist Collection id");
                if (!CreateCollection(collection.ID)) return -1;
                SetCollection(collection);
            }
            return collection.ID;
        }
        public static void RemoveCollection(int id)
        {
            if (Collections.ContainsKey(id))
            {
                Collections.Remove(id);
                Debug.Log("Remove Collection successfully");
            }
            else Debug.Log("does not exist Collection id");
        }
        public static bool CreateCollection(int id)
        {
            if (Collections.ContainsKey(id))
            {
                Debug.Log("Collection key occupant");
                return false;
            }
            Collections.Add(id, new Collection(id));
            Debug.Log("Create New Collection");
            return true;
        }
        


        
    }

    [Serializable]
    public class RouteStoreSerialize: ISerializationCallbackReceiver
    {
        
        public List<int> rotesDataKey;
        public List<Route> routesDataValue;
        public List<int> collectionsDataKey;
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
                collectionsDataKey = new List<int>(RouteStore.Collections.Keys);
                collectionsDataValue = new List<Collection>(RouteStore.Collections.Values);
            }
            catch { return; }
            
        }

        public void OnAfterDeserialize()
        {
            RouteStore.Collections = new Dictionary<int, Collection>();
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
