using com.ab.mvcshop.core.mvc;
using UnityEngine;

namespace com.ab.mvcshop.core.command
{
    /// <summary>
    /// Base ScriptableObject definition for the Command pattern.
    /// </summary>
    public abstract class CommandSo : ScriptableObject, ICommand
    {
        public virtual IModel GetCost(CommandContext ctx) => default;

        public virtual void Execute(CommandContext ctx) { }
    }
}