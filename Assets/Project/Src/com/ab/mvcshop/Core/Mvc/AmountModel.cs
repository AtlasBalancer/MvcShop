namespace com.ab.mvcshop.core.mvc
{
    public abstract class AmountModel : IModel
    {
        public int Amount;

        public AmountModel(int amount) => 
            Amount = amount;

        public abstract void Combine(IModel model);
    }
}