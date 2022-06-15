using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ScreenInfo", menuName = "RouteSystem/ScreenInfo", order = 1)]

    public class ScreenInfo: ScriptableObject
    {
        public string _name;
        public string description;
        public List<Photo> photos;

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
