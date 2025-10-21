using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.gold.model
{
    public interface IGoldService : INotifyModelChanged<Gold>, ICommandCanExecute
    {
        int Amount { get; }
        void ChangeAmount(int valueToChange);
    }
}