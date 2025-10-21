using R3;
using System;
using Zenject;
using UnityEngine;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.modules.gold.model;
using com.ab.mvcshop.modules.gold.definition;

namespace com.ab.mvcshop.modules.gold.interaction
{
    public class GoldController : ViewController<GoldView>
    {
        readonly Settings _settings;
        readonly IGoldService _service;

        protected GoldController(
            SignalBus signals,
            Settings settings,
            IGoldService service,
            IViewFactory factory)
            : base(settings.GoldPanelRoot, signals, settings.ViewAddressKey, factory)
        {
            _service = service;
            _settings = settings;
        }

        public override void BindView(GoldView view)
        {
            view.IncreaseAmount.onClick.AddListener(OnChangeAmountExternal);
            
            _service.ModelChanged
                .Select(item => item.Amount)
                .DistinctUntilChanged()
                .Subscribe( view.UpdateAmount)
                .AddTo(Disposables);
        }

        public override void UnBindView(GoldView view)
        {
            view.IncreaseAmount.onClick.RemoveListener(OnChangeAmountExternal);
            Disposables.Clear();
        }

        public override void Subscribe(SignalBus signals) =>
            Signals.Subscribe<GoldChangeAmountSignal>(OnChangeAmount);

        public override void Unsubscribe(SignalBus signals) => 
            Signals.Unsubscribe<GoldChangeAmountSignal>(OnChangeAmount);

        public void OnChangeAmountExternal() => 
            OnChangeAmount(new GoldChangeAmountSignal(
                _settings.IncreaseAmountValueToChange));

        public void OnChangeAmount(GoldChangeAmountSignal signal)
        {
            var valueToChange = signal.ValueToChange;
            _service.ChangeAmount(valueToChange);
        }

        [Serializable]
        public class Settings
        {
            public int IncreaseAmountValueToChange;
            public RectTransform GoldPanelRoot;
            public const string GOLD_PANEL_ROOT_KEY = "GoldPanelRoot";
            public string ViewAddressKey = GoldAddressKey.GoldAmountPanel.ToString();
        }
    }
}