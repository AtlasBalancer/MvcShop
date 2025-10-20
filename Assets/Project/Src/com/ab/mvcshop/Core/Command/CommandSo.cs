using UnityEngine;

namespace com.ab.mvcshop.core.command
{
    /// <summary>
    /// Base ScriptableObject definition for the Command pattern.
    /// </summary>
    public abstract class CommandSo : ScriptableObject, ICommand
    {
        public virtual bool CanExecute(CommandContext ctx) => 
            true;

        public virtual void Execute(CommandContext ctx) { }
    }
}