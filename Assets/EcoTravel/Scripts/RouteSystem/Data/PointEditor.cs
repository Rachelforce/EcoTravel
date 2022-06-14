using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace routeSystem
{
    [CreateAssetMenu(fileName = "PointEditor", menuName = "RouteSystem/PointEditor", order = 1)]
    public class PointEditor : ScriptableObject
    {
        public int ID;
        public int roateID;
        public string locationString;
        public bool visible;
        public GameObject gameObject;

        public int size { get; set; }
        public bool interactive { get; set; }

        public string _name;
        public string description;
        public List<Photo> photos;
    }
}
