using com.ab.mvcshop.core.mvc;

namespace com.ab.mvcshop.core.command
{
    public interface ICommandCanExecute
    {
        /// <summary>
        /// Return <c>true</c> if command available to execute
        /// </summary>
        bool CanExecute(CommandContext ctx, IModel model);
    }
}