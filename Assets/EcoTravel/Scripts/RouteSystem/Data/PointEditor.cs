using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "PointEditor", menuName = "RouteSystem/PointEditor", order = 1)]
    public class PointEditor : ScriptableObject
    {
        public List<Point> ListInRoute;
        public int ID;
        public int routeID;
        public string locationString;
        public bool visible;
        public GameObject gameObject;

        public int size { get; set; }
        public bool interactive { get; set; }

        public string _name;
        public string description;
        public List<Photo> photos;


        public void GetPoint()
        {
            if (RouteStore.ContainsRoute(ID))
            {
                ListInRoute = RouteStore.RoutesData[routeID].pointList;
                if (ListInRoute != null)
                {
                    if (ID < ListInRoute.Count)
                    {
                        Point point = RouteStore.RoutesData[routeID].pointList[ID];
                        locationString = point.locationString;
                        visible = point.visible;
                        gameObject = point.gameObject;

                        size = point.size;
                        interactive = point.interactive;
                        _name = point.screenInfo._name;
                        description  = point.screenInfo.description;
                        photos = point.screenInfo.photos;
                        Debug.Log("Get Point successfully");
                    }
                    else Debug.Log("does not exist Point ID");
                }
                else Debug.Log("List in Point Empty");
            }
            else Debug.Log("does not exist Route ID");
        }
        public int CreatePoint()
        {
            int emptyIndex = RouteStore.RoutesData[routeID].EmptyPointIndex();
            RouteStore.RoutesData[routeID].pointList.Add(new Point(emptyIndex));
            Debug.Log("Create New Point");
            return emptyIndex;
        }
        public void SetPoint()
        {
            if (RouteStore.RoutesData[routeID].ContainsPointIndex(ID))
            {
                Point point = new Point(ID, routeID);
                point.visible = visible;
                point.gameObject = gameObject;
                point.locationString = locationString;

                point.size =  size;
                point.interactive = interactive;
                point.screenInfo._name = _name;
                point.screenInfo.description = description;
                point.screenInfo.photos = photos;

                RouteStore.RoutesData[routeID].pointList[ID] = point;
                Debug.Log("Set Point successfully");
            }
            else
            {
                Debug.Log("does not exist Point ID");
                ID = CreatePoint();
                SetPoint();
            }



        }
    }
}
