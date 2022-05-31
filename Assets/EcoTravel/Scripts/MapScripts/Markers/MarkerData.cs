using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarkerData", menuName = "Marker/MarkerData", order = 1)]
public class MarkerData : ScriptableObject
{
    private List<Marker> markers;
    public Marker GetMarker(int index)
    {
        return markers[index];
    }
    public void SetMarker(Marker marker)
    {
        if(markers == null) markers = new List<Marker>();
        markers.Add(marker);
        marker.ID = markers.Count;
    }
}
