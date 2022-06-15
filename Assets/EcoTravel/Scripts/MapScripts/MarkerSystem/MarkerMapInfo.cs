using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

namespace Map.MarkerSystem
{
    public  class MarkerMapInfo
    {
        [Geocode]
        public string _locationStrings;
        public Vector2d location {get => Conversions.StringToLatLon(_locationStrings);}
        public float scale { get; set; }
        public bool interactivity { get; set; }
        public bool onScene { get; set; }
        public GameObject markerGameObject { get; set; }
    }
}
