using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "RoadEditor", menuName = "RouteSystem/RoadEditor", order = 1)]
    public class RoadEditor : ScriptableObject
    {
        public int ID;
        public int roateID;
        public string locationString;
        public bool visible;
        public GameObject gameObject;
    }
}
