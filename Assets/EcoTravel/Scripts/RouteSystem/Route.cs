using System.Collections.Generic;
using UnityEngine;
using System;
namespace routeSystem
{
    [System.Serializable]
    public class Route
    {
        public List<Point> pointList;
        public List<Road> roadList;
        public ScreenInfo screenInfo;
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
        public Route(int id, ScreenInfo _screenInfo)
        {
            ID=id;
            screenInfo = _screenInfo;

        }

        public int EmptyRoadIndex()
        {
            return roadList.Count;
        }
        public int EmptyPointIndex()
        {
            return pointList.Count;
        }
        public bool ContainsRoadIndex( int i)
        {
            return i < roadList.Count;
        }
        public bool ContainsPointIndex(int i)
        {
            return i < pointList.Count;
        }
    }
}
