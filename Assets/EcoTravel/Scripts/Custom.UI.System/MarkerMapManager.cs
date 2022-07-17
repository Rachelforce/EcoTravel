using UnityEngine;
using UnityEngine.UI;
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
		[SerializeField] ForwardGeocodeUserInput forwardGeocodeUserInput;

		[SerializeField] GameObject _markerPrefab;
		[SerializeField] GameObject roadObject;
		List<Vector2d> _locations;
		List<GameObject> _spawnedObjects;
		List<float> _spawnScale;
		
		LineRenderer _lineRenderer;
		bool roadRender  = false;

		public delegate void ChangeLocation(string location);
		public event ChangeLocation changeTo;

		enum MarkerType { route, point};
		public void LoadColectionMarkers(Collection collection)
		{
			DestroyMarkers();
			ResetLists();
			List<Route> routes = collection.GetFromStore();
			changeTo?.Invoke(routes[0].locationString);
			List<Marker> markers = new List<Marker>();
			foreach (Route route in routes)
			{
				markers.Add(route);
			}
			SetNewMarkers(markers, MarkerType.route);
		}
		public void LoadColectionMarkers(int id)
		{
			Collection collection = RouteStore.GetCollection(id);
			if (collection != null)
				LoadColectionMarkers(collection);
			else Debug.Log("does not exist Collection id");
		}
		
		public void LoadRouteMarkers(Route route)
		{
			DestroyMarkers();
			ResetLists();

			changeTo?.Invoke(route.locationString);

			List<Marker> markers = new List<Marker>();
			foreach (Point point in route.points)
            {
				markers.Add(point);
			}
			SetNewMarkers(markers, MarkerType.point);
			
			var instance = Instantiate(roadObject);
			_lineRenderer = instance.GetComponent<LineRenderer>();
			_lineRenderer.SetPositions(GetPointPositionToRoad());
			roadRender = true;
			
		}
		public void LoadRouteMarkers(int routeId)
        {
			Route route = RouteStore.RoutesData[routeId];
			LoadRouteMarkers(route);

		}

        private void Awake()
        {
			changeTo += forwardGeocodeUserInput.HandleUserInput;
		}
        private void LateUpdate()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				SetMapTransform(_spawnedObjects[i], _locations[i], _spawnScale[i]);
			}
			if (roadRender)
			{
				var pos = GetPointPositionToRoad();
				_lineRenderer.positionCount = pos.Length;
				_lineRenderer.SetPositions(pos);
			}
		}
		

		
		private void DestroyMarkers()
		{
			if (_spawnedObjects != null && _spawnedObjects.Count != 0)
			{
				foreach (GameObject obj in _spawnedObjects)
				{
					MapMarkerButton mapMarkerButton = obj.GetComponentInChildren<MapMarkerButton>();
					//mapMarkerButton.markerClick -= markerPopUpmenuController.MarkerButtonClick;
					Destroy(obj);

				}
				if (roadRender)
				{
					var roadobj = _lineRenderer.gameObject;
					Destroy(roadobj);
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

				mapMarkerButton.screenInfo = marker;
				mapMarkerButton.markerClick += markerPopUpmenuController.MarkerButtonClick;

				_spawnedObjects.Add(instance);
				_locations.Add(local);
				_spawnScale.Add(scale);
				SetMapTransform(instance, local, scale);

				instance.GetComponentInChildren<Renderer>().enabled = marker.visible;
				instance.GetComponentInChildren<Collider>().enabled = marker.interactive;
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
			for(int i = 0;i < _spawnedObjects.Count;i++)
            {
				pos[i] = _spawnedObjects[i].transform.position;
            }
			
			return pos;

		}



		

	}
}
