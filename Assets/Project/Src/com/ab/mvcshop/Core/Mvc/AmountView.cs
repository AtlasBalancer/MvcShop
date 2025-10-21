using TMPro;
using UnityEngine.UI;

namespace com.ab.mvcshop.core.mvc
{
    public class AmountView : BaseView
    {
        public TMP_Text Amount;
        public Button IncreaseAmount;

        public void UpdateAmount(string amount) =>
            Amount.SetText(amount);
        
        public void UpdateAmount(int amount) => 
            Amount.SetText("{0}",amount);
    }
}