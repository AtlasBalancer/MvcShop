using UnityEngine;

namespace com.ab.mvcshop.core.playerdata
{
    public class ShopScenePayLoad : MonoBehaviour
    {
        public int BundleID;

        public void UpdateBundleId(int id) => 
            BundleID = id;
    }
}