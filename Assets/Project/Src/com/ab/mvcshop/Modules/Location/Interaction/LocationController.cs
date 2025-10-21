using System;
using com.ab.mvcshop.core.mvc;
using UnityEngine;
using Zenject;

namespace com.ab.mvcshop.modules.location
{
    public class LocationController : ViewController<LocationPanelView>
    {
        readonly Settings _settings;
        readonly ILocationService _service;

        public LocationController(
            SignalBus signals,
            Settings settings,
            ILocationService service,
            IViewFactory factory)
            : base(settings.PanelRoot, signals, settings.ViewAddressKey, factory)
        {
            _service = service;
            _settings = settings;
        }

        public override void BindView(LocationPanelView view)
        {
            // _service.ModelChanged
                // .Select(item => item.Amount)
                // .DistinctUntilChanged()
                // .Subscribe(view.UpdateAmount)
                // .AddTo(Disposables);
        }

        public override void UnBindView(LocationPanelView view)
        {
            // view.IncreaseAmount.onClick.RemoveListener(OnChangeAmountExternal);
            // Disposables.Clear();
        }

        public override void Subscribe(SignalBus signals) =>
            Signals.Subscribe<LocationChangeAmountSignal>(OnChangeAmount);

        public override void Unsubscribe(SignalBus signals) =>
            Signals.Unsubscribe<LocationChangeAmountSignal>(OnChangeAmount);

        // public void OnChangeAmountExternal() =>
            // OnChangeAmount(new LocationChangeAmountSignal(
                // _settings.IncreaseAmountValueToChange));

        public void OnChangeAmount(LocationChangeAmountSignal signal)
        {
            // var valueToChange = signal.ValueToChange;
            // _service.ChangeAmount(valueToChange);
        }

        [Serializable]
        public class Settings
        {
            // public int IncreaseAmountValueToChange;
            public RectTransform PanelRoot;
            public string ViewAddressKey = LocationAddressKey.LocationAmountPanel.ToString();
        }
    }

    public class LocationChangeAmountSignal
    {
    }
}