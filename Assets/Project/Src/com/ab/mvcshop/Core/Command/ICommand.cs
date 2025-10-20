namespace com.ab.mvcshop.core.command
{
    public interface ICommand
    {
        /// <summary>
        /// Return <c>true</c> if command available to execute
        /// </summary>
        bool CanExecute(CommandContext ctx);

        /// <summary>
        /// Execute business logic
        /// </summary>
        void Execute(CommandContext ctx);
    }
}