namespace Map.MarkerSystem
{
    public  class MarkerData 
    {
        public int ID;
        public MarkerScreenInfo markerScreenInfo { get; set; }
        public MarkerMapInfo markerMapInfo { get; set; }  

        public MarkerData (int id)
        {
            ID = id;
        }
    }
}
