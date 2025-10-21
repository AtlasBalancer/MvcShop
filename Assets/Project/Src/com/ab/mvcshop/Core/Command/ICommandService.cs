using System.Collections.Generic;
using UnityEngine;

namespace com.ab.mvcshop.core.command
{
    public interface ICommandService
    {
        void Execute(List<ICommand> executions);
        CommandCostComposite CastSoToCommandCostAction(List<ScriptableObject> soActions);
    }
}