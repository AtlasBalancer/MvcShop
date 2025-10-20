using UnityEngine;

namespace com.ab.mvcshop.core.mvc
{
    public interface IViewFactory
    {
        public TView Create<TView>(string id, Transform root = null) where TView : IView;
    }
}