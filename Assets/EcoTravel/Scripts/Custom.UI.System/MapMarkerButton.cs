using System;
using UnityEngine;
using routeSystem;

namespace Custom.UI.System
{
    public class MapMarkerButton: MonoBehaviour
    {
        [SerializeField] private ScreenInfo screenInfo;
        [SerializeField] private MarkerPopUpmenuController popUpmenuController;
        public delegate void MarkerClick(ScreenInfo _screenInfo);
        public event MarkerClick markerClick;
        private void Awake()
        {
            markerClick += popUpmenuController.MarkerButtonClick; 
        }

        void OnMouseDown() { }
        void OnMouseUpAsButton()
        {
            markerClick?.Invoke(screenInfo);
        }
    }
}
