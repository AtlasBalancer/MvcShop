using TMPro;
using UnityEngine.UI;
using com.ab.mvcshop.core.mvc;
using UnityEngine;

namespace com.ab.mvcshop.modules.location
{
    public class LocationPanelView : BaseView
    {
        public AdvancedDropdown DropDown;

        public Button ChangeButton;
        public Animator ChangeButtonAnimator;

        public TMP_Text CurrentLocation;

        public void ActiveChoseLocation(bool active) => 
            DropDown.transform.localScale = active ? Vector3.one : Vector3.zero;

        public void ActiveButton(bool active) =>
            ChangeButton.gameObject.SetActive(active);

        public void ActiveDropDown()
        {
            ChangeButton.interactable = false;
            ChangeButtonAnimator.SetTrigger("Normal");

            ActiveChoseLocation(true);
            DropDown.OpenOptions();
        }

        public void ActiveButton(int _)
        {
            ChangeButton.interactable = true;

            ActiveChoseLocation(false);
            DropDown.CloseOptions();
        }

        public void SetUp()
        {
            ActiveChoseLocation(false);
            ChangeButton.onClick.AddListener(ActiveDropDown);
            DropDown.onChangedValue += ActiveButton;
        }

        public void UpdateLocation(string location) =>
            CurrentLocation.SetText(location);

        void OnDestroy()
        {
            ChangeButton.onClick.RemoveListener(ActiveDropDown);
            DropDown.onChangedValue -= ActiveButton;
        }
    }
}