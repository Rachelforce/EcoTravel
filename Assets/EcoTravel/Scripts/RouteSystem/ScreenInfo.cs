using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace routeSystem
{


    public class ScreenInfo : DataBaseObject
    {
        public string title;
        public string description;

        public List<string> conveniences { get => ConvertStringToList(conveniencesString); }
        public List<string> availability { get => ConvertStringToList(availabilityString); }
        public List<string> other { get => ConvertStringToList(otherString); }

        public string conveniencesString;
        public string availabilityString;
        public string otherString;

        public string photoURLsString;
        [NonSerialized] public List<Photo> photos;
       
        List<string> ConvertStringToList(string content)
        {
            List<string> list = new List<string>();
            if (content != null)
            {
                string[] array = new string[3];
                array = content.Split(",");
                list = new List<string>(array);
            }
            return list;
        }
        string ConvertListToString(List<string> list)
        {
            string content = "";
            foreach (var item in list)
            {
                content += "," + item.ToString();
            }
            return content;
        }
        string GetPhotoName(string url)
        {
            return url.Split('/').Last();
        }
        public List<Texture2D> GetPhotosTexture()
        {
            if (photos == null) return null;
            List<Texture2D> outList = new List<Texture2D>();
            foreach (var photo in photos)
            {
                outList.Add(photo.GetTextureFromStore());
            }
            return outList;
        }

        public bool InitializePhotoList()
        {
            if (String.IsNullOrEmpty(photoURLsString)) {
                Debug.Log("Photo List intialize false - photoURLsString is Empty. ScreenInfo id --" + ID);
                return false; }
            List<string> urlList = ConvertStringToList(photoURLsString);
            photos = new List<Photo>();
            foreach (var item in urlList)
            {
                photos.Add(new Photo(GetPhotoName(item), item));
            }
            Debug.Log("Photo List intialize done");
            return true;
        }


        

        
    }
}
