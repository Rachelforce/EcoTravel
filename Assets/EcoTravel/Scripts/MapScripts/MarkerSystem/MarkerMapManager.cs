using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;
using Mapbox.Examples;
using routeSystem;
using System.Collections;

namespace Custom.UI.System
{
    public class MarkerMapManager : MonoBehaviour
    {
		[SerializeField]AbstractMap _map;
		[SerializeField] MarkerPopUpmenuController markerPopUpmenuController;
		[SerializeField] GameObject _markerPrefab;
		[SerializeField] GameObject roadObject;
		List<Vector2d> _locations;
		List<GameObject> _spawnedObjects;
		List<float> _spawnScale;
		
		LineRenderer _lineRenderer;
		bool roadRender  = false;

		enum MarkerType { route, point}; 
		public void LoadColectionMarkers(Collection colection)
		{
			DestroyMarkers();
			ResetLists();
			List<Route> routes = colection.GetFromStore();
			List<Marker> markers = new List<Marker>();
			foreach (Route route in routes)
			{
				markers.Add(route);
			}
			SetNewMarkers(markers, MarkerType.route);

		}
		public void LoadRouteMarkers(Route route)
		{
			
			ResetLists();
			List<Marker> markers = new List<Marker>();
			foreach (Point point in route.pointList)
            {
				markers.Add(point);
			}
			SetNewMarkers(markers, MarkerType.point);
			
			var instance = Instantiate(roadObject);
			_lineRenderer = instance.GetComponent<LineRenderer>();
			_lineRenderer.SetPositions(GetPointPositionToRoad());
			roadRender = true;

		}


		void Start()
		{
			LoadColectionMarkers(RouteStore.Collections["Main"]);
		}
		
		private void Update()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				SetMapTransform(_spawnedObjects[i], _locations[i], _spawnScale[i]);
			}
			if(roadRender) _lineRenderer.SetPositions(GetPointPositionToRoad());
		}
		

		
		private void DestroyMarkers()
		{
			if (_spawnedObjects != null && _spawnedObjects.Count != 0)
			{
				foreach (GameObject obj in _spawnedObjects)
				{
					MapMarkerButton mapMarkerButton = obj.GetComponentInChildren<MapMarkerButton>();
					mapMarkerButton.markerClick -= markerPopUpmenuController.MarkerButtonClick;
					obj.Destroy();
				}
				if (roadRender)
				{
					var roadobj = _lineRenderer.gameObject;
					roadobj.Destroy();
					roadRender = false;
				}
			}
		}
		private void ResetLists()
        {
			_spawnScale = new List<float>();
			_locations = new List<Vector2d>();
			_spawnedObjects = new List<GameObject>();
		}
		private void SetNewMarkers(List<Marker> markers, MarkerType markerType)
        {
			foreach (Marker marker in markers)
			{
				var local = marker.GetLocation();
				var scale = marker.size;
				var instance = Instantiate(_markerPrefab);
				MapMarkerButton mapMarkerButton;
				if (markerType == MarkerType.route)
                {
					mapMarkerButton = instance.transform.GetChild(0).gameObject.AddComponent<MapRoutButton>();
					((MapRoutButton)mapMarkerButton).loadRoute += LoadRouteMarkers;
					((MapRoutButton)mapMarkerButton).route = (Route)marker;
				}
				else mapMarkerButton = instance.transform.GetChild(0).gameObject.AddComponent<MapPointButton>();

				mapMarkerButton.screenInfo = marker.screenInfo;
				mapMarkerButton.markerClick += markerPopUpmenuController.MarkerButtonClick;

				_spawnedObjects.Add(instance);
				_locations.Add(local);
				_spawnScale.Add(scale);
				SetMapTransform(instance, local, scale);

				instance.GetComponentInChildren<Renderer>().enabled = marker.visible;
				instance.GetComponentInChildren<Collider>().isTrigger = !marker.interactive;
			}
		}
		private void SetMapTransform(GameObject obj, Vector2d location, float scale)
		{
			obj.transform.localPosition = _map.GeoToWorldPosition(location, true);
			obj.transform.localScale = new Vector3(scale, scale, scale);
		}
		private Vector3[] GetPointPositionToRoad()
        {
			var pos = new Vector3[_spawnedObjects.Count];
			for(int i = 0;i< _spawnedObjects.Count;i++)
            {
				pos[i] = _spawnedObjects[i].transform.position;
            }
			return pos;

		}
		

	}
}
