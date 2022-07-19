using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using routeSystem;
using UnityEngine.Events;

namespace Custom.UI.System
{
    public class SearchView : MonoBehaviour
    {

        [SerializeField] SearchController searchController;
        [SerializeField] MarkerMapManager markerMapManager;
        [SerializeField]  MarkerPopUpmenuController popUpmenuController;

        [SerializeField] Transform contentParent;
        [SerializeField] GameObject markerPenel;

        private List<GameObject> swapObject = new List<GameObject>();
        private void Awake()
        {
            searchController.OnFound += ShowSearchList;
        }
        public void ShowSearchList(List<Marker> listMarker)
        {
            HideSwapObject();
            if (listMarker != null)
            {
                Debug.Log("Show");
                foreach (Marker marker in listMarker)
                {
                    var instance = Instantiate(markerPenel, contentParent);
                    PrefadLinks prefadLinks = instance.GetComponent<PrefadLinks>();
                    prefadLinks.SetText(new List<string> { marker.title});
                    prefadLinks.SetButtonsCallbacks(markerMapManager.LoadRouteMarkersbyId, marker.ID);
                    swapObject.Add(instance);
                }
            }
            else
            {
                Debug.Log("Search List is empty");
            }
           
        }
        private void HideSwapObject()
        {
            if (swapObject.Count > 0)
            {
                foreach (GameObject item in swapObject)
                {
                    Destroy(item);
                }
            }
        }
    }
}
