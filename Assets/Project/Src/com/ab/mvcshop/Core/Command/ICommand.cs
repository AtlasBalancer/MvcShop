using com.ab.mvcshop.core.mvc;

namespace com.ab.mvcshop.core.command
{
    public interface ICommand
    {

        IModel GetCost(CommandContext ctx);

        /// <summary>
        /// Execute business logic
        /// </summary>
        void Execute(CommandContext ctx);
    }
}