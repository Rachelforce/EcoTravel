using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System;
namespace routeSystem
{
    [Serializable]
    public class Marker
    {
        public int ID;

        public bool visible;
        public bool interactive;
 
        public int size;
        public string locationString;
        public Vector2d GetLocation()
        {
            return Conversions.StringToLatLon(locationString);
        }
        
        public ScreenInfo screenInfo;
    }
}
