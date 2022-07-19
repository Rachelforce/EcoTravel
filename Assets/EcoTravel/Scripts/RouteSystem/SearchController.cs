using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace routeSystem
{

    public class SearchController : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputField;

        public delegate void Found(List<Marker> list);
        public event Found OnFound;

        

        public void SerchFromField()
        {
            string key = inputField.text;
            List<Marker> list = SerchByRoute(key);
            OnFound?.Invoke(list);
        }
        private List<Marker> SerchByRoute(string key)
        {
            List<Marker> allRoute = new List<Marker>(RouteStore.RoutesData.Values);
            List<Marker> foundRoute =  GiveCoincidences(key, allRoute);
            return foundRoute;
        }
        private List<Marker> GiveCoincidences(string key, List<Marker> inputList)
        {
            Debug.Log(key);
            List<Marker> foundList = new List<Marker>();
            foreach (Marker marker in inputList)
            {
                if (marker.title == key) { 
                    foundList.Add(marker);
                    continue;
                }
                if(marker.description == key) {
                    foundList.Add(marker);
                    continue;
                }
                foreach (string content in SplitString(marker.title))
                {
                    if (content == key)
                    {
                        foundList.Add(marker);
                        break;
                    }
                }

            }
            return foundList;
        }
        private string[] SplitString(string content)
        {
            string[] array = new string[3];
            if (content != null)
            { 
                char[] splitChars= new char[3] { ',',' ', '.' };
                array = content.Split(splitChars, 3);
                
            }
        return array;
        }
        
    }
}
