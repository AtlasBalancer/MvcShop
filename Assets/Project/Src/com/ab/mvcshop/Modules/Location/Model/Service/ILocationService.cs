using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.location
{
    public interface ILocationService : INotifyModelChanged<Location>, ICommandCanExecute
    {
        void ChangeAmount(string valueToChange);
    }
}