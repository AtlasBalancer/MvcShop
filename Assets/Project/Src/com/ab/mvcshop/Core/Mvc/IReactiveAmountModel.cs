using System;

namespace Project.Src.com.ab.mvcshop.Core.Mvc
{
    public interface IReactiveAmountModel : IAmountReadOnlyModel
    {
        IObservable<int> AmountChanged { get; }
    }
}