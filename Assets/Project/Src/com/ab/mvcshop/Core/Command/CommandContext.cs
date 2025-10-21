using Zenject;

namespace com.ab.mvcshop.core.command
{
    public class CommandContext
    {
        public SignalBus Signals;

        public CommandContext(SignalBus signals) => 
            Signals = signals;
    }
}