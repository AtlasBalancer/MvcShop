using System;
using com.ab.mvcshop.core.mvc;
using R3;
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
            _service.ModelChanged
                .Select(item => item.Title)
                .DistinctUntilChanged()
                .Subscribe(_ => view.UpdateLocation(_service.Title))
                .AddTo(Disposables);
        }

        public override void Subscribe(SignalBus signals) =>
            Signals.Subscribe<LocationChangeSignal>(OnChangeAmount);

        public override void Unsubscribe(SignalBus signals) =>
            Signals.Unsubscribe<LocationChangeSignal>(OnChangeAmount);


        public void OnChangeAmount(LocationChangeSignal signal)
        {
            var valueToChange = signal.ValueToChange;
            _service.ChangeAmount(valueToChange);
        }

        [Serializable]
        public class Settings
        {
            public RectTransform PanelRoot;
            public string ViewAddressKey = LocationAddressKey.LocationPanel.ToString();
        }
    }
}