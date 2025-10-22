using com.ab.mvcshop.core.mvc;

namespace com.ab.mvcshop.core.playerdata
{
    public interface IPlayerDataService
    {
        T Get<T>();
        void CommitAsync<T>(T model);
        void Init<TModel>(bool rewrite = false) where TModel : IModel;
    }
}