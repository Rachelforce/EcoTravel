using UnityEngine;
using System;
using PhotoSystem;

namespace routeSystem
{
    [System.Serializable]
    
    public class Photo
    {
        
        public string _url;
        public string namePhoto;
        public Texture2D texture { get => GetTextureFromStore(); }

        public Photo() { }
        public Photo(string _name, string url)
        {
            namePhoto =_name;
            _url = url;

        }
        public Texture2D GetTextureFromStore()
        {
            if(String.IsNullOrEmpty(namePhoto)) return null;
            Texture2D texture = PhotoStore.LoadTextureFromDisk(namePhoto);
            return texture;
        }

    }
}

