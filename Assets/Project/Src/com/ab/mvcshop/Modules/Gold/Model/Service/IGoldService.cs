using Rx = R3;

namespace com.ab.mvcshop.modules.gold.model
{
    public interface IGoldService 
    {
        int Amount { get; }

        public Rx.Observable<int> AmountChanged { get; }
        void ChangeAmount(int valueToChange);
    }
}