using UnityEngine.ResourceManagement.AsyncOperations;

namespace com.ab.mvcshop.core.assetlaod
{
    public interface IAddressableService
    {
        public T Load<T>(string key);

        public AsyncOperationHandle<T> LoadAsync<T>(string key);
    }
}