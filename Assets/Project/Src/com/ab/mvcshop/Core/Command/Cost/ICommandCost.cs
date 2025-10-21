using System;
using System.Collections.Generic;
using com.ab.mvcshop.core.mvc;

namespace com.ab.mvcshop.core.command
{
    public interface ICommandCost 
    {
        Dictionary<Type, IModel> Cost { get; }
    }
}