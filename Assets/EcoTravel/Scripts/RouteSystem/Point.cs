using UnityEngine;
using System;
namespace routeSystem
{
    [Serializable]
    public class Point : Marker
    {
        public int routeID;

        #region Constructor
        public Point()
        {

        }
        public Point(int id)
        {
            ID = id;
        }
        public Point(int id, int roateId)
        {
            ID = id;
            routeID = roateId;
           
        }
        public Point(int id, int roateId, string _locationString)
        {
            ID = id;
            routeID = roateId;
            locationString = _locationString;
            
        }
        public Point(int id, int routeid, string _locationString, 
            bool _visible, GameObject _gameObject,
            int _size, bool _interactive,
            ScreenInfo _screenInfo)
        {
            ID = id;
            routeID = routeid;
            locationString = _locationString;
            

        }
        #endregion Constructor

        
    }
}
