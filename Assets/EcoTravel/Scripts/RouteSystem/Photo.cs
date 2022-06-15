using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Photo", menuName = "RouteSystem/Photo", order = 1)]

    public class Photo : ScriptableObject
    {
        public string url;
        public string path;
        public Texture2D texture;

  
    }
}

