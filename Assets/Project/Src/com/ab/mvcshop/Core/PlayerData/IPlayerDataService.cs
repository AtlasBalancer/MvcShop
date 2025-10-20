using Project.Src.com.ab.mvcshop.Core.Mvc;

namespace com.ab.mvcshop.core.playerdata
{
    public interface IPlayerDataService
    {
        void Init<TModel>(bool rewrite = false) where TModel : IModel;
        T Get<T>();
        void CommitAsync<T>(T model);
    }
}