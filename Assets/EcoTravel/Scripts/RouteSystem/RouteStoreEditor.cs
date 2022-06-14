using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

namespace routeSystem
{
    public class RouteStoreEditor : MonoBehaviour
    {
        [SerializeField] RouteEditor routeEditor;
        [SerializeField] int roatID;
        [SerializeField] bool getRoat;
        [SerializeField] bool setRoat;
        
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




        /*
        [SerializeField] private bool get;
        [SerializeField] private bool set;

        [Space]

        [SerializeField] int ID;
        [SerializeField] private DataType dataType;

        [Space]
        [Space]
        [Header("ScreenInfo")]
        [Space]

        [SerializeField] private string _name;
        [SerializeField] private string description;
        [SerializeField] private List<Texture> photos;

        [Space]

        [Header("MapInfo")]
        [Space]

        [SerializeField]
        [Geocode]
        private string locationStrings;
        [SerializeField] private float scale;
        [SerializeField] private bool interactivity;
        [SerializeField] private bool onScene;
        [SerializeField] private GameObject markerGameObject;

        enum DataType
        {
            Marker,
            ScreenInfo,
            MapInfo
        }
        private void Update()
        {
            if (get)
            {
                GetInfo(dataType);
                get = false;
            }
            if (set)
            {
                SetInfo(dataType);
                set = false;
            }

        }
        private void GetInfo(DataType _dataType)
        {
            switch (_dataType)
            {
                case DataType.Marker:
                    GetInfo(DataType.ScreenInfo);
                    GetInfo(DataType.MapInfo);
                    break;

                case DataType.ScreenInfo:
                    MarkerScreenInfo markerScreenInfo = MarkerStore.getMarkerScreenInfo(ID);
                    _name = markerScreenInfo._name;
                    description = markerScreenInfo.description;
                    photos = markerScreenInfo.photos;
                    break;

                case DataType.MapInfo:
                    MarkerMapInfo markerMapInfo = MarkerStore.getMarkerMapInfo(ID);
                    locationStrings = markerMapInfo._locationStrings;
                    scale = markerMapInfo.scale;
                    interactivity = markerMapInfo.interactivity;
                    onScene = markerMapInfo.onScene;
                    markerGameObject = markerMapInfo.markerGameObject;
                    break;
            }
        }
        private void SetInfo(DataType _dataType)
        {
            switch (_dataType)
            {
                case DataType.Marker:
                    SetInfo(DataType.ScreenInfo);
                    SetInfo(DataType.MapInfo);
                    break;
                case DataType.ScreenInfo:
                    ID = MarkerStore.setMarkerScreenInfo(ID, CreateMarkerScreenInfo());
                    break;
                case DataType.MapInfo:
                    ID = MarkerStore.setMarkerMapInfo(ID, CreateMarkerMapInfo());
                    break;
            }
        }
        private MarkerMapInfo CreateMarkerMapInfo()
        {
            MarkerMapInfo markerMapInfo = new MarkerMapInfo();
            markerMapInfo._locationStrings = locationStrings;
            markerMapInfo.scale = scale;
            markerMapInfo.interactivity = interactivity;
            markerMapInfo.onScene = onScene;
            markerMapInfo.markerGameObject = markerGameObject;
            return markerMapInfo;
        }
        private MarkerScreenInfo CreateMarkerScreenInfo()
        {
            MarkerScreenInfo markerScreenInfo = new MarkerScreenInfo();
            markerScreenInfo._name = _name;
            markerScreenInfo.description = description;
            markerScreenInfo.photos = photos;
            return markerScreenInfo;
        }
        */
    }
}
