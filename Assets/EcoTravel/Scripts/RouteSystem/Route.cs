using System.Collections.Generic;
using System;
namespace routeSystem
{
    [Serializable]
    public class Route:Marker
    {
        public List<Point> pointList;
        public Road road;    
        public Route()
        {
            pointList = new List<Point>();
            road = new Road(ID);
            screenInfo = new ScreenInfo();
        }
        public Route(int id)
        {
            ID = id;
            pointList = new List<Point>();
            road = new Road(ID);
            screenInfo = new ScreenInfo();
        }
        public Route(int id, ScreenInfo _screenInfo)
        {
            ID=id;
            screenInfo = _screenInfo;
            pointList = new List<Point>();
            road = new Road(ID);

        }

        
        public int EmptyPointIndex()
        {
            if (pointList == null) return 0;
            return pointList.Count;
        }
        public bool ContainsPointIndex(int i)
        {
            if(pointList == null) return false;
            return i < pointList.Count;
        }
    }
}
