using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.mvc;
using UnityEngine;

namespace com.ab.mvcshop.modules.location
{
    [CreateAssetMenu (fileName = "$NAME$LocationCheckCommandDef",menuName = "Commands/Location check")]
    public class LocationCheckCommandSo : CommandSo
    {
        public string ValueToChange;

        public override IModel GetCost(CommandContext ctx) => 
            new Location(ValueToChange);

        public override void Execute(CommandContext ctx)
        { }
    }
}