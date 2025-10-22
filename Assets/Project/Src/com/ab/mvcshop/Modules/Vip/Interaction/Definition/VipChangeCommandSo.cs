using System;
using UnityEngine;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.modules.vip.model;
using com.ab.mvcshop.modules.vip.interaction.Signals;

namespace com.ab.mvcshop.modules.vip.Interaction
{
    
    [CreateAssetMenu (fileName = "$NAME$VipChangeAmountCommandDef",menuName = "Commands/Vip change amount")]
    public class VipChangeCommandSo : CommandSo
    {
        public int ChangeSeconds;

        public override IModel GetCost(CommandContext ctx) => 
            new Vip(TimeSpan.FromSeconds(ChangeSeconds));

        public override void Execute(CommandContext ctx)
        {
            base.Execute(ctx);
            ctx.Signals.Fire(new VipChangeSignal(TimeSpan.FromSeconds(ChangeSeconds)));
        }
    }
}