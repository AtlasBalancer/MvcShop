using System;
using R3;

namespace com.ab.mvcshop.core.playerdata
{
    public interface INotifyModelService : IDisposable
    {
        void OnChange();
        Observable<Unit> Changed { get; }
    }
}