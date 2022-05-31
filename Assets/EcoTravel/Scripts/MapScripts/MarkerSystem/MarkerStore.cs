using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.MarkerSystem{

    public class MarkerStore :ScriptableObject 
    {
        public List<MarkerData> mainMarkersList { get;set; }
    }
}
