using R3;

namespace com.ab.mvcshop.core.playerdata
{
    public interface INotifyModelChanged<TModel> 
    {
        Observable<TModel> ModelChanged { get; }
    }
}