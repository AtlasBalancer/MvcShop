using System;
using Zenject;
using UnityEngine;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.shop.definition
{
    public class ShopPayloadInstaller : MonoInstaller
    {
        public Settings _settings;
        
        public override void InstallBindings()
        {
            SetUpPayLoadContainer();
            Container.BindInstance(_settings.PayLoad);
        }

        void SetUpPayLoadContainer()
        {
            if (_settings.PayLoadContainer == null)
                return;

            // _settings.PayLoadContainer.parent = null;
            // Object.DontDestroyOnLoad(_settings.PayLoadContainer);
        }
        
        [Serializable]
        public class Settings
        {
            public Transform PayLoadContainer;
            public ShopScenePayLoad PayLoad;
        }
    }
}