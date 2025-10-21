using R3;
using Rx = R3;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.gold.model
{
    public class GoldService : IGoldService
    {
        readonly IPlayerDataService _persistent;
        readonly INotifyModelService _notifyModel;

        readonly BehaviorSubject<Gold> _model;
        public Rx.Observable<Gold> ModelChanged => _model;

        public GoldService(
            CommandInvoker commandInvoker,
            INotifyModelService notifyModel,
            IPlayerDataService persistent)
        {
            _notifyModel = notifyModel;
            _persistent = persistent;
            _persistent.Init<Gold>();
            Gold persistRef = _persistent.Get<Gold>();
            _model = new BehaviorSubject<Gold>(persistRef);

            commandInvoker.Registry(typeof(Gold), this);
        }

        public int Amount
        {
            get => _model.Value.Amount;
            private set
            {
                if (value == _model.Value.Amount) return;

                _model.Value.Amount = value;
                _model.OnNext(_model.Value);
                _notifyModel.OnChange();
            }
        }

        public void ChangeAmount(int valueToChange) =>
            UpdateAmount(Amount + valueToChange);

        void UpdateAmount(int amount)
        {
            Amount = amount;
            _persistent.CommitAsync(_model);
        }

        public bool CanExecute(CommandContext ctx, Gold model) =>
            _model.Value.Amount >= model.Amount;

        public bool CanExecute(CommandContext ctx, IModel model)
        {
            var gold = (Gold)model;
            var execute = (_model.Value.Amount + gold.Amount) >= 0;
            return execute;
        }
    }
}