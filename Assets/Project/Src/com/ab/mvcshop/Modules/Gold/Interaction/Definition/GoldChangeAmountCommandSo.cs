using UnityEngine;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.modules.gold.definition;
using com.ab.mvcshop.modules.gold.model;

namespace com.ab.mvcshop.Modules.gold.definition
{
    [CreateAssetMenu (fileName = "$NAME$GoldChangeAmountCommandDef",menuName = "Commands/Gold change amount")]
    public class GoldChangeAmountCommandSo : CommandSo
    {
        public int ValueToChange;

        public override IModel GetCost(CommandContext ctx) => 
            new Gold(ValueToChange);

        public override void Execute(CommandContext ctx)
        {
            base.Execute(ctx);
            ctx.Signals.Fire(new GoldChangeAmountSignal(ValueToChange));
        }
    }
}