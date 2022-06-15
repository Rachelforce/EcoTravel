using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "RouteEditor", menuName = "RouteSystem/RouteEditor", order = 1)]
    public class RouteEditor : ScriptableObject
    {
        public int ID;
        public List<Point> pointList;
        public List<Road> roadList;


        public string _name;
        public string description;
        public List<Photo> photos;

    }
}
