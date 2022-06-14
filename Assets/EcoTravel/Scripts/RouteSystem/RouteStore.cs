using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    public class RouteStore : MonoBehaviour
    {
        static public Dictionary<int,Route> RoutesData { get; set; }
  
    }
}
