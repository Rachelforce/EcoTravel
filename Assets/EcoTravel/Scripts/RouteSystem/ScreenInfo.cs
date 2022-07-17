using System.Collections.Generic;
using System;
using UnityEngine;

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

        
        [NonSerialized]public List<Photo> photos;
       
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

        

        
    }
}
