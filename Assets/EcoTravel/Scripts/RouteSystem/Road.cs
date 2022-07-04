using System.Collections.Generic;
using Mapbox.Utils;
using UnityEngine;
namespace routeSystem
{
    [System.Serializable]
    public class Road 
    {
        public int routeID;
        public List<Vector2d> pointPositions;
 
        public Road(int roateId)
        {
            routeID = roateId;
            //SetPointPosition();
        }
        public void SetPointPosition()
        {
            pointPositions = new List<Vector2d>();
            foreach (Point point in RouteStore.RoutesData[routeID].pointList)
            {
                pointPositions.Add(point.GetLocation());
                Debug.Log(pointPositions.Count);
            }
            
        }
    }
}
