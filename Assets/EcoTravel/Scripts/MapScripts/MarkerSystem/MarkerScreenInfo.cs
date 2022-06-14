using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Map.MarkerSystem { 
    public  class MarkerScreenInfo
    {
        public string _name { get; set; }
        public string description { get; set; }
        public List<Texture> photos { get; set; }
        public MarkerScreenInfo()
        {
            photos = new List<Texture>();
        }
    }
}
