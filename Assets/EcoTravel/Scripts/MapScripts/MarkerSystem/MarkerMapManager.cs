using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;
using Mapbox.Examples;


namespace Map.MarkerSystem
{
    public class MarkerMapManager : MonoBehaviour
    {
		[SerializeField]
		AbstractMap _map;

		[Geocode]
		[SerializeField]
		List<string> _locationStrings;
		List<Vector2d> _locations;
		[SerializeField] List<GameObject> _spawnedObjects;

		[SerializeField]float _spawnScale;

		GameObject _markerPrefab;

		//List<GameObject> spawnedObjects;

		
		void Start()
		{
			_locations = new List<Vector2d>();
			//spawnedObjects = new List<GameObject>();

			for (int i = 0; i < _locationStrings.Count; i++)
			{
				var locationString = _locationStrings[i];
				_locations.Add(Conversions.StringToLatLon(locationString));
				//var instance = Instantiate(_markerPrefab);
				SetMapTransform(_spawnedObjects[i], _locations[i], _spawnScale);
			}
		}
		
		private void Update()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				SetMapTransform(_spawnedObjects[i], _locations[i], _spawnScale);
			}
		}
		/*
		private void LoadStartMarkers()
        {
			
			
			if(MarkerStore.mainMarkerCount>0)
            {
				for(int i = 0; i < MarkerStore.mainMarkerCount; i++)
                {
					MarkerMapInfo markerMapInfo = MarkerStore.getMarkerMapInfo(i);
					GameObject instance = Instantiate(_markerPrefab);
					spawnedObjects.Add(instance);
					SetMapTransform(instance, markerMapInfo.location, markerMapInfo.scale);
				}
            }
			
        
		}
		*/
		private void SetMapTransform(GameObject obj, Vector2d location, float scale)
        {
			obj.transform.localPosition = _map.GeoToWorldPosition(location, true);
			obj.transform.localScale = new Vector3(scale, scale, scale);
		}

	}
}
