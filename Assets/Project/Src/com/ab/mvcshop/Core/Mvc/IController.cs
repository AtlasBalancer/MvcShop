using System;
using Zenject;

namespace Project.Src.com.ab.mvcshop.Core.Mvc
{
    public interface IController : IDisposable
    {
        void Initialize();

        void Subscribe(SignalBus signals);

        void Unsubscribe(SignalBus signals);
    }
}