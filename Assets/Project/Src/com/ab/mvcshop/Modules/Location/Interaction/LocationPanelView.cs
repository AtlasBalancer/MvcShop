using TMPro;
using com.ab.mvcshop.core.mvc;
using UnityEngine.UI;

namespace com.ab.mvcshop.modules.location
{
    public class LocationPanelView : BaseView
    {
        public Button ChangeLocation;
        public TMP_Text CurrentLocation;

        public void UpdateLocation(string location) => 
            CurrentLocation.SetText(location);
    }
}