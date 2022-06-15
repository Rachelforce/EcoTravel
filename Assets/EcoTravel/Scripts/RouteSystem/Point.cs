using UnityEngine;
namespace routeSystem
{
    [System.Serializable]
    public class Point : Marker
    {

        public ScreenInfo screenInfo { get; set; }
        public int size { get; set; }
        public bool interactive { get; set; }

        #region Constructor
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
