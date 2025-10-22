using R3;
using Zenject;
using UnityEngine;

namespace com.ab.mvcshop.core.mvc
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
            IViewFactory factory)
        {
            _root = root;
            Signals = signals;
            View = factory.Create<TView>(viewAddressableKey);
        }

        public virtual void Initialize()
        {
            View.Show(_root);
            Show(View);
        }

        public virtual void Show(TView view)
        {
            Subscribe(Signals);
            BindView(View);
        }

        public virtual void Hide(TView view)
        {
            Unsubscribe(Signals);
            UnBindView(View);
        }
        
        public abstract void BindView(TView view);
        public virtual void UnBindView(TView view){}

        public virtual void Subscribe(SignalBus signals){}
        public virtual void Unsubscribe(SignalBus signals){}

        public void Dispose()
        {
            UnBindView(View);
            Unsubscribe(Signals);
            Disposables.Dispose();
        }
    }
}