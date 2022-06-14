namespace routeSystem
{
    [System.Serializable]
    public class Point : Marker
    {

        public ScreenInfo screenInfo { get; set; }
        public int size { get; set; }
        public bool interactive { get; set; }

        #region Constructor
        public Point(int id, int roateId, string _locationString)
        {
            ID = id;
            roateID = roateId;
            locationString = _locationString;
        }
        public Point(int id, int roateId, string _locationString, ScreenInfo _screenInfo)
        {
            ID = id;
            roateID = roateId;
            locationString = _locationString;
            screenInfo = _screenInfo;
        }
        #endregion Constructor
    }
}
