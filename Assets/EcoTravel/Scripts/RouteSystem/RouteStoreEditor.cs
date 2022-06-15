using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

namespace routeSystem
{
    public class RouteStoreEditor : MonoBehaviour
    {
        #region Set variables
        [SerializeField] RouteEditor routeEditor;
        [SerializeField] int routID;
        [SerializeField] bool getRout;
        [SerializeField] bool setRout;

        [Space]
        [Space]

        [SerializeField] PointEditor pointEditor;
        [SerializeField] int pointID;
        [SerializeField] bool getPoint;
        [SerializeField] bool setPoint;

        [Space]
        [Space]

        [SerializeField] RoadEditor roadEditor;
        [SerializeField] int roadID;
        [SerializeField] bool getRoad;
        [SerializeField] bool setRoad;
        #endregion variables

        #region GetSetMethods
        private void Update()
        {
            if (getRout) GetRout();
            else if (setRout) SetRout();
            else if (getPoint) GetPoint();
            else if (setPoint) SetPoint();
            else if (getRoad) GetRoad();
            else if (setRoad) SetRoad();
        }
        private void GetRout()
        {
            Route route = RouteStore.RoutesData[routID];
            routeEditor.ID = route.ID;
            routeEditor.pointList = route.pointList;
            routeEditor.roadList = route.roadList;

            routeEditor._name = route.screenInfo._name;
            routeEditor.description = route.screenInfo.description;
            routeEditor.photos = route.screenInfo.photos;

            getRout = false;
        }
        private void GetRoad()
        {
            Road road = RouteStore.RoutesData[roadID].roadList[roadID];
            roadEditor.ID = road.ID;
            roadEditor.roateID = road.roateID;
            roadEditor.locationString = road.locationString;

            getRoad = false;
        }
        private void GetPoint()
        {
            Point point = RouteStore.RoutesData[routID].pointList[pointID];
            pointEditor.ID = point.ID;
            pointEditor.roateID = point.roateID;
            pointEditor.locationString = point.locationString;
            pointEditor.visible = point.visible;
            pointEditor.gameObject = point.gameObject;

            pointEditor.size = point.size;
            pointEditor.interactive = point.interactive;

            pointEditor._name = point.screenInfo._name;
            pointEditor.description = point.screenInfo.description;
            pointEditor.photos = point.screenInfo.photos;
            getPoint = false;
        }

        private void SetRout()
        {
            Route route = new Route(routID, routeEditor.pointList, routeEditor.roadList
                ,new ScreenInfo(routeEditor._name, routeEditor.description, routeEditor.photos));
            RouteStore.SetRoute(roadID, route);
            setRout = false;
        }  
        private void SetPoint()
        {
            Point point = new Point(pointID, routID,
                pointEditor.locationString, pointEditor.visible,
                pointEditor.gameObject, pointEditor.size,
                pointEditor.interactive, 
                new ScreenInfo(pointEditor._name, pointEditor.description
                , pointEditor.photos));
            RouteStore.SetPoint(ref routID,ref pointID, point);
            setPoint = false;   
        }
        private void SetRoad()
        {
            Road road = new Road(roadID, routID);
            RouteStore.SetRoad(ref routID, ref roadID, road);
            setRoad = false;
        }
        #endregion GetSetMethods
        
        
    }
}
