namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Map;
	using UnityEngine;

	public class ImmediatePositionWithLocationProvider : MonoBehaviour
	{
		[SerializeField] ForwardGeocodeUserInput forwardGeocodeUserInput;
		bool _isInitialized;

		ILocationProvider _locationProvider;
		ILocationProvider LocationProvider
		{
			get
			{
				if (_locationProvider == null)
				{
					_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				}

				return _locationProvider;
			}
		}

		Vector3 _targetPosition;

		void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
		}

		void LateUpdate()
		{
			if (_isInitialized)
			{
				var map = LocationProviderFactory.Instance.mapManager;
				transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
				
			}
		}
		
		public void SetCurrentPositionTomap()
        {
			string loc = LocationProvider.CurrentLocation.LatitudeLongitude.ToString();
			loc = PharseGeoCode(loc);
			forwardGeocodeUserInput.HandleUserInput(loc);
		}
		string PharseGeoCode(string input)
		{
			string[] array = input.Split(",");
			string output = array[1] + "," + array[0];
			return output;

		}
	}
}