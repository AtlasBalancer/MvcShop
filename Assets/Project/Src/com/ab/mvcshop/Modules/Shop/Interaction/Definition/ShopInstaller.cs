using System;
using com.ab.mvcshop.modules.shop.model;
using UnityEngine;
using Zenject;

namespace com.ab.mvcshop.modules.shop.definition
{
    public class ShopInstaller : MonoInstaller
    {
        public Settings _settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ShopController>().AsSingle().NonLazy();
            Container.BindInstance(_settings.Controller);
            
            Container.Bind<IShopService>().To<ShopService>().AsSingle();
            Container.BindInstance(_settings.Service).AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public RectTransform ShopRoot;
            public ShopService.Settings Service;
            public ShopController.Settings Controller;
        }
    }
}