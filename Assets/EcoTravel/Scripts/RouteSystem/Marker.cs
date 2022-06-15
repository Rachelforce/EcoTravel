using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
namespace routeSystem
{
    [System.Serializable]
    public class Marker
    {
        public int ID { get; set; }
        public int roateID { get; set; }
        public string locationString { get; set; }
        public Vector2d location {get => Conversions.StringToLatLon(locationString);}
        public bool visible { get; set; }
        public GameObject gameObject { get; set; }
        
    }
}
