using R3;
using Rx = R3;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.gold.model
{
    public class GoldService : IGoldService
    {
        Gold _model;
        BehaviorSubject<int> _amount;

        readonly IPlayerDataService _persistent;

        public Rx.Observable<int> AmountChanged => _amount;

        public GoldService(IPlayerDataService persistent)
        {
            _persistent = persistent;
            _persistent.Init<Gold>();
            _model = _persistent.Get<Gold>();
            _amount = new BehaviorSubject<int>(_model.Amount);
        }

        public int Amount
        {
            get => _model.Amount;
            private set
            {
                if (value == _model.Amount) return;

                _model.Amount = value;
                _amount.OnNext(value);
            }
        }

        public void ChangeAmount(int valueToChange) =>
            UpdateAmount(Amount + valueToChange);

        void UpdateAmount(int amount)
        {
            Amount = amount;
            _persistent.CommitAsync<Gold>(_model);
        }
    }
}