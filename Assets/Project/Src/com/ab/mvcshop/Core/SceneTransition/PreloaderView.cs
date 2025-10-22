using UnityEngine;

namespace com.ab.mvcshop.core.playerdata
{
    public class PreloaderView : MonoBehaviour
    {
        public void Active(bool active) =>
            gameObject.SetActive(active);
    }
}