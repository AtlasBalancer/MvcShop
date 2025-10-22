using UnityEngine;

namespace com.ab.mvcshop.core.mvc
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public virtual void Show(Transform parent = null, bool saveWorld = false)
        {
            if(parent != null)
                SetParent(parent, saveWorld);
            
            gameObject.SetActive(true);
        }

        public virtual void Hide() => 
            gameObject.SetActive(false);

        public void SetParent(Transform parent, bool saveWorld = false) => 
            transform.SetParent(parent, saveWorld);
    }
}