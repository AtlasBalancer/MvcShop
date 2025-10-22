using System;
using com.ab.mvcshop.core.playerdata;
using Zenject;

namespace com.ab.mvcshop.core.definition
{
    public class PreloaderInstaller : MonoInstaller
    {
        public Settings _settings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInstance(_settings.SceneLoader).AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public SceneLoaderService.Settings SceneLoader;
        }
    }
}