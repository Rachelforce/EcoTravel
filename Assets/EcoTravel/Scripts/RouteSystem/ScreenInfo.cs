using System.Collections.Generic;

namespace routeSystem
{
    [System.Serializable]
    public class ScreenInfo 
    {
        public string _name { get; set; }
        public string description { get; set; }
        public List<Photo> photos { get; set; }

        public ScreenInfo()
        {
            photos = new List<Photo>();
        }
        public ScreenInfo(string __name, string _description, List<Photo> _photos)
        {
            _name = __name;
            description = _description;
            photos = _photos;
        }
    }
}
