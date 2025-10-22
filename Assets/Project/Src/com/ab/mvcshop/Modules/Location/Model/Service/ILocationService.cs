using System.Collections.Generic;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.playerdata;

namespace com.ab.mvcshop.modules.location
{
    public interface ILocationService : INotifyModelChanged<Location>, ICommandCanExecute
    {
        string Title { get; }
        public IEnumerable<string> LocationLocalizedOptions { get; }
        void ChangeAmount(string valueToChange);
        void ChangeAmount(int indexLocation);
    }
}