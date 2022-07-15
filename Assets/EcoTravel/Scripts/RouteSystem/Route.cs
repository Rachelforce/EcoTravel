using System.Collections.Generic;
using System;
namespace routeSystem
{
    [Serializable]
    public class Route:Marker
    {
        public List<Point> points;
        public Road road;    

        public Route()
        {
            points = new List<Point>();
            road = new Road(ID);
        }
        public Route(int id)
        {
            ID = id;
            points = new List<Point>();
            road = new Road(ID);
        }
        
    }
}
