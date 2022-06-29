using UnityEngine;
using System;

namespace routeSystem
{
    [System.Serializable]
    
    public class Photo 
    {
        public string url;
        public string path;
        [NonSerialized]public Texture2D texture;

  
    }
}

