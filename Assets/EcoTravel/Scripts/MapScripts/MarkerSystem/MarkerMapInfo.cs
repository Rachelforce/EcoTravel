using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.MarkerSystem
{
    public class MarkerMapInfo
    {
        public string coordinates { get; set; }
        public float Size { get; set; }
        public bool interactivity { get; set; }
        public bool onScene { get; set; }
        public GameObject markerGameObject { get; set; }
    }
}
