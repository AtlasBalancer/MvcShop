using System;
using UnityEngine;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.modules.vip.model;

namespace com.ab.mvcshop.modules.vip.Interaction
{
    [CreateAssetMenu (fileName = "$NAME$VipCheckCommandDef",menuName = "Commands/Vip check amount")]
    public class VipCheckCommandSo : CommandSo
    {
        public override IModel GetCost(CommandContext ctx) => new Vip(TimeSpan.Zero);

        public override void Execute(CommandContext ctx)
        { }
    }
}