using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.health.model
{
    public interface IHealthService : INotifyModelChanged<Health>, ICommandCanExecute
    {
        int Amount { get; }
        void ChangeAmount(int valueToChange);
    }
}