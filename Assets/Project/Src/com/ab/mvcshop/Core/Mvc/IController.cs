using System;
using Zenject;

namespace com.ab.mvcshop.core.mvc
{
    public interface IController : IDisposable
    {
        void Initialize();

        void Subscribe(SignalBus signals);

        void Unsubscribe(SignalBus signals);
    }
}