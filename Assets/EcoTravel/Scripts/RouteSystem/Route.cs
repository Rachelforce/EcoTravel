using System.Collections.Generic;
using UnityEngine;
using System;
namespace routeSystem
{
    [System.Serializable]
    public class Route
    {
        [NonSerialized] public List<Point> pointList;
        [NonSerialized] public List<Road> roadList;
        [NonSerialized] public ScreenInfo screenInfo;
        public int ID;
        public Route()
        {
            pointList = new List<Point>();
            roadList = new List<Road>();
            screenInfo = new ScreenInfo();
        }
        public Route(int id)
        {
            ID = id;
            pointList = new List<Point>();
            roadList = new List<Road>();
            screenInfo = new ScreenInfo();
        }
        public Route(int id, List<Point> points, List<Road> roads, ScreenInfo _screenInfo)
        {
            ID=id;
            pointList = points;
            roadList = roads;
            screenInfo = _screenInfo;

        }
    }
}
