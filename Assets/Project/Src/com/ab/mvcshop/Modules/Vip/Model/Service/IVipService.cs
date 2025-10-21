using System;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.vip.model
{
    public interface IVipService: INotifyModelChanged<Vip>, ICommandCanExecute, IDisposable
    {
        void ChangeAmount(TimeSpan valueToChange);
    }
}