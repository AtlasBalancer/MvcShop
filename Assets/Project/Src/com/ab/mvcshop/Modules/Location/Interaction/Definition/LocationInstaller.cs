using System;
using com.ab.mvcshop.core.playerdata;
using Zenject;

namespace com.ab.mvcshop.modules.location
{
    public class LocationInstaller : MonoInstaller
    {
        public Settings _settings;

        public override void InstallBindings()
        {
            DevProfile();

            Container.BindInterfacesAndSelfTo<LocationController>().AsSingle().NonLazy();
            Container.BindInstance(_settings.Controller).AsSingle();
            Container.Bind<ILocationService>().To<LocationService>().AsSingle();
            Container.DeclareSignal<LocationChangeSignal>();
        }

        void DevProfile()
        {
#if DEVELOPMENT
            if (!_settings.Default.OverrideModel)
                return;

            var dataService = Container.Resolve<MockPlayerDataService>();
            dataService.Registry<Location>(_settings.Default.Model);
#endif
        }

        [Serializable]
        public class Settings
        {
            public MockData Default;
            public LocationController.Settings Controller;
        }

        [Serializable]
        public class MockData
        {
            public Location Model;
            public bool OverrideModel;
        }
    }
}