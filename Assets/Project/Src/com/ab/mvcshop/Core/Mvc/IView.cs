using UnityEngine;

namespace com.ab.mvcshop.core.mvc
{
    public interface IView
    {
        void Show(Transform parent = null, bool saveWorld = false);

        void Hide();
    }
}