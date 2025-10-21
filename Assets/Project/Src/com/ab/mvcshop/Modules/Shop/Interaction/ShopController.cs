using R3;
using System;
using Zenject;
using UnityEngine;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.modules.shop.model;
using com.ab.mvcshop.modules.shop.definition;
using com.ab.mvcshop.modules.shop.interaction;

namespace com.ab.mvcshop.modules.shop
{
    public class ShopController : ViewController<ShopView>
    {
        readonly Settings _settings;
        readonly ShopService Service;
        readonly IShopService _service;
        readonly IViewFactory _factory;
        readonly CommandInvoker _commandInvoker;
        readonly BundlesPresenter _bundlesPresenter;

        public ShopController(
            SignalBus signals,
            Settings settings,
            IShopService service,
            CommandInvoker commandInvoker,
            IViewFactory factory)
            : base(settings.ShopRoot, signals, settings.ShopViewAddressKey, factory)
        {
            _commandInvoker = commandInvoker;
            _service = service;
            _settings = settings;
            _factory = factory;
            _bundlesPresenter = new();
        }

        public override void Show(ShopView view)
        {
            base.Show(view);
            CreateBundles();
            OnCheckBundleAvailabilityCondition();
            _service.ModelChanged.Subscribe(_ =>
                    OnCheckBundleAvailabilityCondition())
                .AddTo(Disposables);
        }

        public void OnCheckBundleAvailabilityCondition()
        {
            foreach (var item in _bundlesPresenter.Refs)
            {
                CommandCostComposite cost = item.Value.Bundle.Conditions;

                var canExecute = _commandInvoker.CanExecute(cost);
                item.Value.View.BuyAvailable(canExecute);
            }
        }

        public override void BindView(ShopView view)
        {
            _bundlesPresenter.BuyClick.Subscribe(OnBuyClick)
                .AddTo(Disposables);
        }

        public void OnBuyClick(int bundleId)
        {
            var bundle = _bundlesPresenter.GetBundle(bundleId);
            _service.BuyBundle(bundle);
        }

        public override void Subscribe(SignalBus signals)
        {
        }

        public override void Unsubscribe(SignalBus signals)
        {
        }

        void CreateBundles()
        {
            foreach (var item in _service.GetBundles())
            {
                var bundle = _factory.Create<BundleView>(_settings.BundleViewAddressKey, View.BundlesRoot);
                bundle.SetUp(item);
                _bundlesPresenter.Add(item, bundle);
            }
        }

        [Serializable]
        public class Settings
        {
            public RectTransform ShopRoot;

            public string ShopViewAddressKey = ShopAddressKey.ShopView.ToString();
            public string BundleViewAddressKey = ShopAddressKey.BundleView.ToString();
        }
    }
}