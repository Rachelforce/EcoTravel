using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System;
using System.Collections.Generic;

namespace routeSystem
{
    [Serializable]
    public class Marker: ScreenInfo
    {

        public bool visible;
        public bool interactive;
 
        public int size;
        public string locationString;
        public Vector2d GetLocation()
        {
            return Conversions.StringToLatLon(locationString);
        }

    }
}
