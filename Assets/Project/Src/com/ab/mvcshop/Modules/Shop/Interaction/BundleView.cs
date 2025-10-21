using TMPro;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.modules.shop.model;
using UnityEngine.UI;

namespace com.ab.mvcshop.modules.shop
{
    public class BundleView : BaseView
    {
        public TMP_Text Description;
        public Button Buy;
        public TMP_Text NotEnoughResource;
        int _id;

        public void SetUp(Bundle item)
        {
            _id = item.Id;
            Description.SetText(item.Message);
        }

        public void BuyAvailable(bool canExecute)
        {
            Buy.interactable = canExecute;
            Buy.gameObject.SetActive(canExecute);
            NotEnoughResource.gameObject.SetActive(!canExecute);
        }
    }
}