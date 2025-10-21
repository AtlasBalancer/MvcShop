using System.Collections.Generic;
using UnityEngine;

namespace com.ab.mvcshop.modules.shop.definition
{
    [CreateAssetMenu(fileName = "#Name#BundleListDef", menuName = "Bundles/List")]
    public class BundleListSo : ScriptableObject
    {
        public List<BundleSo> Bundles;
    }
}