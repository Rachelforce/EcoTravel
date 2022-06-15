using System.Collections.Generic;
using UnityEngine;
namespace routeSystem
{
    [System.Serializable]
    public class Route : MonoBehaviour
    {
        public List<Point> pointList { get; set; }
        public List<Road> roadList { get; set; }
        public ScreenInfo screenInfo { get; set; }
        public int ID { get; set; }
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
