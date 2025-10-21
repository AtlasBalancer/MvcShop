using System;
using com.ab.mvcshop.core.mvc;
using TMPro;
using UnityEngine;

namespace com.ab.mvcshop.modules.vip.interaction
{
    public class VipPanelView : BaseView
    {
        public TMP_Text Time;

        public void UpdateTime(TimeSpan time) => 
            Time.text = time.ToString(@"mm\:ss");
    }
}