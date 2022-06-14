using System.Collections.Generic;

namespace routeSystem
{
    [System.Serializable]
    public class ScreenInfo 
    {
        public string _name { get; set; }
        public string description { get; set; }
        public List<Photo> photos { get; set; }
    }
}
