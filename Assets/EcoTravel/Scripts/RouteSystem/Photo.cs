using UnityEngine;

namespace routeSystem
{
    [System.Serializable]
    public class Photo : MonoBehaviour
    {
        string url { get; set; } 
        string path { get; set; }
        Texture2D texture { get; set; }

  
    }
}

