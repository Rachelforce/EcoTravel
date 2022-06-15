namespace routeSystem
{
    [System.Serializable]
    public class Road : Marker
    {
        public Road(int id, int roateId, string _locationString)
        {
            ID = id;
            roateID = roateId;
            locationString = _locationString;
        }
        public Road(int id)
        {
            ID = id;
        }
        public Road(int id, int roateId) {
            ID = id;
            roateID = roateId;
        }
    }
}
