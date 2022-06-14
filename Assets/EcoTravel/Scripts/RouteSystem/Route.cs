using System.Collections.Generic;
using UnityEngine;
namespace routeSystem
{
    [System.Serializable]
    public class Route : MonoBehaviour
    {
        public List<Marker> pointList { get; set; }
        public List<Marker> roadList { get; set; }
        public ScreenInfo screenInfo { get; set; }
        public int ID { get; set; }
    }
}
