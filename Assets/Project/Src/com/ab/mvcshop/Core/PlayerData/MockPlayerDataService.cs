using System;
using UnityEngine;
using System.Collections.Generic;
using com.ab.mvcshop.core.mvc;

namespace com.ab.mvcshop.core.playerdata
{
    public class MockPlayerDataService : IPlayerDataService
    {
        readonly string _keyPersistentPattern;
        const string PERSISTEN_SYFIX = "MockData";

        public MockPlayerDataService(Settings settings)
        {
            _keyPersistentPattern = $"{PERSISTEN_SYFIX}_{settings.PersistentDataVersion}_";
        }

        Dictionary<Type, IModel> _storage = new();


        public void Init<TModel>(bool rewerite = false) where TModel : IModel
        {
            var key = typeof(TModel);
            if (_storage.ContainsKey(key))
            {
                if(!rewerite)
                    return;
                
                _storage.Remove(key);
            }
            
            var data = PlayerPrefs.GetString(GetPersistKey(key));
            TModel parsed = JsonUtility.FromJson<TModel>(data);
            _storage.Add(key, parsed);
        }

        public void Registry<T>(IModel model) =>
            _storage.Add(typeof(T), model);

        public T Get<T>()
        {
            var key = typeof(T);
            if (!_storage.ContainsKey(key))
            {
                Debug.LogError($"{nameof(MockPlayerDataService)}::");
            }

            return (T)_storage[key];
        }

        public void CommitAsync<T>(T model)
        {
            PlayerPrefs.SetString(
                GetPersistKey(typeof(T)),
                ParseToJSONString(model));
        }

        string ParseToJSONString<T>(T model) =>
            JsonUtility.ToJson(model);

        string GetPersistKey(Type t) =>
            $"{_keyPersistentPattern}{t.Name}";

        
        [Serializable]
        public class Settings
        {
            public string PersistentDataVersion;
        }

    }

}