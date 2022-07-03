using System.Collections.Generic;
using UnityEngine;
using System;
namespace routeSystem
{
    [System.Serializable]
    
    public class ScreenInfo
    {
        public string _name;
        public string description;
        public List<Photo> photos;

        public ScreenInfo()
        {
            _name = "someName";
            description = "SomeDescription";
            photos = new List<Photo>();
        }
        public ScreenInfo(string __name, string _description, List<Photo> _photos)
        {
            _name = __name;
            description = _description;
            photos = _photos;
        }

        public int EmptyPhotoIndex()
        {
            return photos.Count;
        }
        public bool ContainsPhotoIndex(int i)
        {
            return i < photos.Count;
        }
    }
}
