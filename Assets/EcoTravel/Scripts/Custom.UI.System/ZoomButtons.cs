using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;

namespace Custom.UI.System
{
    
    public class ZoomButtons : MonoBehaviour
    {
        [SerializeField] AbstractMap map;
        [SerializeField] float speed;
        public void ZoomIn()
        {
            float value = map.Zoom;
            map.UpdateMap(map.CenterLatitudeLongitude, value + speed);

        }
        public void ZoomOut()
        {
            float value = map.Zoom;
            map.UpdateMap(map.CenterLatitudeLongitude, value - speed);

        }

    }
}
