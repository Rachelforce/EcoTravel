using routeSystem;

namespace Custom.UI.System
{
    public class MapRoutButton : MapMarkerButton
    {
        public delegate void LoadRoute(Route route);
        public event LoadRoute loadRoute;
        public Route route;
        public override void ButtonEvent()
        {
            base.ButtonEvent();
            loadRoute?.Invoke(route);

        }
    }
}
