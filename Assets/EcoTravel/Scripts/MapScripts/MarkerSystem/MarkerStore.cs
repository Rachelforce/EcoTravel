using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.MarkerSystem{

    [CreateAssetMenu(fileName = "MarkerStore", menuName = "MarkerSystem/MarkerStore", order = 1)]
    public  class MarkerStore: ScriptableObject 
    {
        public static List<MarkerData> mainMarkersList;

        public static int mainMarkerCount { get { return mainMarkersList.Count; } }

        public static MarkerMapInfo getMarkerMapInfo(int index) => mainMarkersList[index].markerMapInfo;
        public static MarkerScreenInfo getMarkerScreenInfo(int index) => mainMarkersList[index].markerScreenInfo;

        public static int setMarkerMapInfo(int index, MarkerMapInfo markerMapInfo)
        {
            index = CheckIndex(index);
            mainMarkersList[index].markerMapInfo = markerMapInfo;
            return index;
        }
        public static int setMarkerScreenInfo(int index, MarkerScreenInfo markerScreenInfo)
        {
            index = CheckIndex(index);
            mainMarkersList[index].markerScreenInfo = markerScreenInfo;
            return index;
        }

        private static int CheckIndex(int index)
        {
            if(mainMarkersList == null)
            {
                mainMarkersList = new List<MarkerData>();
                return CheckIndex(0);
            }
            if (index == mainMarkersList.Count)
            {
                mainMarkersList.Add(new MarkerData(index));
                mainMarkersList[index].markerMapInfo = new MarkerMapInfo();
                mainMarkersList[index].markerScreenInfo = new MarkerScreenInfo();

                return index;
            }
            else if(index < mainMarkersList.Count)
            {
                return index;
            }
            else 
            {
                return CheckIndex(mainMarkersList.Count);
            }
        }

    }
}
