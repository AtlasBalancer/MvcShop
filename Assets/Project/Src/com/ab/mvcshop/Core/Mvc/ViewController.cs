using R3;
using Zenject;
using UnityEngine;
using com.ab.mvcshop.core.mvc;

namespace Project.Src.com.ab.mvcshop.Core.Mvc
{
    public abstract class ViewController<TView> : IController, IInitializable where TView : BaseView
    {
        readonly RectTransform _root;
        protected readonly TView View;
        protected readonly SignalBus Signals;
        protected readonly CompositeDisposable Disposables = new();

        protected ViewController(
            RectTransform root,
            SignalBus signals,
            string viewAddressableKey,
            IViewFactory viewFactory)
        {
            _root = root;
            Signals = signals;
            View = viewFactory.Create<TView>(viewAddressableKey);
        }

        public virtual void Initialize() => 
            View.transform.SetParent(_root, false);

        public abstract void BindView(TView view);
        public virtual void UnBindView(TView view){}

        public abstract void Subscribe(SignalBus signals);
        public abstract void Unsubscribe(SignalBus signals);

        public void Dispose()
        {
            UnBindView(View);
            Unsubscribe(Signals);
            Disposables.Dispose();
        }
    }
}