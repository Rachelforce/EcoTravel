using System;
using UnityEngine;
using routeSystem;
using UnityEngine.EventSystems;

namespace Custom.UI.System
{
    public class MapMarkerButton: MonoBehaviour
    {
        public ScreenInfo screenInfo;
        public delegate void MarkerClick(ScreenInfo _screenInfo);
        public event MarkerClick markerClick;

        void OnMouseDown() { }
        void OnMouseUpAsButton()
        {
            ButtonEvent();
        }
        public virtual void ButtonEvent()
        {
            markerClick?.Invoke(screenInfo);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }
    }
}
