using System;

namespace com.ab.mvcshop.core.mvc
{
    public interface IReactiveAmountModel : IAmountReadOnlyModel
    {
        IObservable<int> AmountChanged { get; }
    }
}