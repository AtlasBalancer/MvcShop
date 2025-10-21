using System;
using com.ab.mvcshop.core.mvc;

namespace com.ab.mvcshop.modules.health.model
{
    [Serializable]
    public class Health : AmountModel
    {
        public Health(int amount) 
            : base(amount) { }

        public override void Combine(IModel model) => 
            Amount += ((Health)model).Amount;
    }
}