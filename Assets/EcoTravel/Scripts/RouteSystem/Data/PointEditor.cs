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

        public int size { get; set; }
        public bool interactive { get; set; }

        public string _name;
        public string description;
        public List<Photo> photos;
        [Space]
        [Space]
        public int photoIndex;
        public string _url;
        public string _path;


        public void GetPoint()
        {
            if (RouteStore.ContainsRoute(routeID))
            {
                ListInRoute = RouteStore.RoutesData[routeID].pointList;
                if (ListInRoute != null)
                {
                    if (ID < ListInRoute.Count)
                    {
                        Point point = RouteStore.RoutesData[routeID].pointList[ID];
                        locationString = point.locationString;
                        visible = point.visible;

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
            if (RouteStore.ContainsRoute(routeID))
            {
                    if (RouteStore.RoutesData[routeID].ContainsPointIndex(ID))
                {
                    Point point = new Point(ID, routeID);
                    point.visible = visible;
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
            else Debug.Log("does not exist Route ID");


        }
        public void GetPhoto()
        {
            if (RouteStore.ContainsRoute(routeID))
            {
                ListInRoute = RouteStore.RoutesData[routeID].pointList;
                if (ListInRoute != null)
                {
                    if (ID < ListInRoute.Count)
                    {
                        photos = RouteStore.RoutesData[routeID].pointList[ID].screenInfo.photos;
                        if (photoIndex < photos.Count)
                        {
                            _url = photos[photoIndex]._url;
                            _path = photos[photoIndex]._path;
                            Debug.Log("Get Photo successfully");
                        }
                        else Debug.Log("does not exist Photo ID");
                    }
                    else Debug.Log("does not exist Point ID");
                }
                else Debug.Log("List in Point Empty");
            }
            else Debug.Log("does not exist Route ID");
        }
        public void SetPhoto()
        {
            if (RouteStore.RoutesData[routeID].pointList[ID].screenInfo.ContainsPhotoIndex(photoIndex))
            {
                Photo photo = new Photo(_path, _url) ;
                RouteStore.RoutesData[routeID].pointList[ID].screenInfo.photos[photoIndex] = photo;
                Debug.Log("Set Photo successfully");
            }
            else
            {
                Debug.Log("does not exist Photo ID");
                photoIndex = CreatePhoto();
                SetPhoto();
            }
        }
        public int CreatePhoto()
        {
            int emptyIndex = RouteStore.RoutesData[routeID].pointList[ID].screenInfo.EmptyPhotoIndex();
            RouteStore.RoutesData[routeID].pointList[ID].screenInfo.photos.Add(new Photo());
            Debug.Log("Create New Photo");
            return emptyIndex;
        }
    }
}
