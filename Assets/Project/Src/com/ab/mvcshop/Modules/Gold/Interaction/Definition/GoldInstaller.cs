using System;
using Zenject;
using UnityEngine;
using com.ab.mvcshop.core.playerdata;
using com.ab.mvcshop.modules.gold.model;
using com.ab.mvcshop.modules.gold.interaction;

namespace com.ab.mvcshop.modules.gold.definition
{
    public class GoldInstaller : MonoInstaller
    {
        [SerializeField] Settings _settings;

        public override void InstallBindings()
        {
            DevProfile();

            Container.BindInterfacesAndSelfTo<GoldController>().AsSingle().NonLazy();
            Container.BindInstance(_settings.GoldController).AsSingle();
            Container.Bind<IGoldService>().To<GoldService>().AsSingle();
            Container.DeclareSignal<GoldChangeAmountSignal>();
        }

        void DevProfile()
        {
#if DEVELOPMENT
            if (!_settings.Default.OverrideModel)
                return;

            var dataService = Container.Resolve<MockPlayerDataService>();
            dataService.Registry<Gold>(_settings.Default.Model);
#endif
        }

        [Serializable]
        public class Settings
        {
            public MockData Default;
            public GoldController.Settings GoldController;
        }

        [Serializable]
        public class MockData
        {
            public Gold Model;
            public bool OverrideModel;
        }
    }
}