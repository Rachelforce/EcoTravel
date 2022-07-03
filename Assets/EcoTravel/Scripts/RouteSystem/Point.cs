using UnityEngine;
using System;
namespace routeSystem
{
    [Serializable]
    public class Point : Marker
    {
        public int roateID;

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
            roateID = roateId;
            screenInfo = new ScreenInfo();
        }
        public Point(int id, int roateId, string _locationString)
        {
            ID = id;
            roateID = roateId;
            locationString = _locationString;
            screenInfo = new ScreenInfo();
        }
        public Point(int id, int routeid, string _locationString, 
            bool _visible, GameObject _gameObject,
            int _size, bool _interactive,
            ScreenInfo _screenInfo)
        {
            ID = id;
            roateID = routeid;
            locationString = _locationString;
            screenInfo = _screenInfo;

        }
        #endregion Constructor

        
    }
}
