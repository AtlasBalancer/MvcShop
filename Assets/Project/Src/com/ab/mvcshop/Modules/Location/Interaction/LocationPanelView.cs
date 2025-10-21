using com.ab.mvcshop.core.mvc;
using R3;
using TMPro;

namespace com.ab.mvcshop.modules.location
{
    public class LocationPanelView : BaseView
    {
        public TMP_Text CurrentLocation;

        public void UpdateLocation(string location) => 
            CurrentLocation.SetText(location);
    }
}