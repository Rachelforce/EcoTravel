using UnityEngine;
using System;

namespace routeSystem
{
    [System.Serializable]
    
    public class Photo 
    {
        public string _url;
        public string _path;

        public Photo() { }
        public Photo(string path)
        {
            _path = path;
            GetTextureFromPath();
        }
        public Photo(string path, string url)
        {
            _path =path;
            _url = url;
        }
        public Texture2D GetTextureFromPath()
        {
            return Resources.Load<Texture2D>(_path);
        }

    }
}

