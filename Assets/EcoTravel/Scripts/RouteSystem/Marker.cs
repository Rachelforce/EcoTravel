using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System;
namespace routeSystem
{
    [System.Serializable]
    public class Marker
    {
        public int ID;
        public int roateID;
        public string locationString;
        
        public bool visible;
        [NonSerialized]public GameObject gameObject;
        public Vector2d GetLocation()
        {
            return Conversions.StringToLatLon(locationString); 
        }
        
    }
}
