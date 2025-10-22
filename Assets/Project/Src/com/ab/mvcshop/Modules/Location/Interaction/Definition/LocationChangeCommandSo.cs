using UnityEngine;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.core.command;

namespace com.ab.mvcshop.modules.location
{
    [CreateAssetMenu (fileName = "$NAME$LocationChangeCommandDef",menuName = "Commands/Location change")]
    public class LocationChangeCommandSo : CommandSo
    {
        public string ValueToChange;

        public override IModel GetCost(CommandContext ctx) => 
            new Location(ValueToChange);

        public override void Execute(CommandContext ctx)
        {
            base.Execute(ctx);
            ctx.Signals.Fire(new LocationChangeSignal(ValueToChange));
        }
    }
}