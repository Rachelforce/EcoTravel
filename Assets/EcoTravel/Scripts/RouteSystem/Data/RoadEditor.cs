using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System.Collections.Generic;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "RoadEditor", menuName = "RouteSystem/RoadEditor", order = 1)]
    public class RoadEditor : ScriptableObject
    {
        public List<Road> ListInRoute;
        public int ID;
        public int routeID;
        public string locationString;
        public bool visible;
        public GameObject gameObject;

        public void GetRoad()
        {
            if (RouteStore.ContainsRoute(ID))
            {
                ListInRoute = RouteStore.RoutesData[routeID].roadList;
                if (ListInRoute != null)
                {
                    if (ID < ListInRoute.Count)
                    {
                        Road road = RouteStore.RoutesData[routeID].roadList[ID];
                        locationString = road.locationString;
                        visible = road.visible;
                        gameObject = road.gameObject;
                        Debug.Log("Get road successfully");
                    }
                    else Debug.Log("does not exist Road ID");
                }
                else Debug.Log("List in Route Empty");
            }
            else Debug.Log("does not exist Route ID");
        }
        public int CreateRoad()
        {
            int emptyIndex = RouteStore.RoutesData[routeID].EmptyRoadIndex();
            RouteStore.RoutesData[routeID].roadList.Add(new Road(emptyIndex));
            Debug.Log("Create New Road");
            return emptyIndex;
        }
        public void SetRoad()
        {
            if (RouteStore.RoutesData[routeID].ContainsRoadIndex(ID))
            {
                Road road = new Road(ID, routeID);
                road.visible = visible;
                road.gameObject = gameObject;
                road.locationString = locationString;

                RouteStore.RoutesData[routeID].roadList[ID] = road;
                Debug.Log("Set road successfully");
            }
            else {
                Debug.Log("does not exist Road ID");
                ID = CreateRoad();
                SetRoad();
            }



        }
    }
}
