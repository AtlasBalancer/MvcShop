using System;
using Zenject;
using UnityEngine;
using com.ab.mvcshop.modules.shop.model;

namespace com.ab.mvcshop.modules.shop.definition
{
    public class SingleBundleInstaller : MonoInstaller
    {
        public Settings _settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SingleBundleController>().AsSingle().NonLazy();
            Container.BindInstance(_settings.Controller);

            Container.Bind<IShopService>().To<ShopService>().AsSingle();
            Container.BindInstance(_settings.Service).AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public ShopService.Settings Service;
            public SingleBundleController.Settings Controller;
        }
    }
}