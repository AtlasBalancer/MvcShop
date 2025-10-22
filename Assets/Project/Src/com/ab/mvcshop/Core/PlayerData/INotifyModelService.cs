using R3;
using System;

namespace com.ab.mvcshop.core.playerdata
{
    public interface INotifyModelService : IDisposable
    {
        void OnChange();
        Observable<Unit> Changed { get; }
    }
}