namespace com.ab.mvcshop.core.mvc
{
    public abstract class AmountModel<T> : IModel
    {
        public T Amount;

        public AmountModel(T amount) => 
            Amount = amount;

        public abstract void Combine(IModel model);
    }
}