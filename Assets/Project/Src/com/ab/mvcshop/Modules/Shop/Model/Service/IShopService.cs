using System.Collections.Generic;
using R3;

namespace com.ab.mvcshop.modules.shop.model
{
    public interface IShopService 
    {
        Bundle GetBundle(int bundleID);
        List<Bundle> GetBundles();
        Observable<Unit> ModelChanged { get; }
        void BuyBundle(Bundle bundle);
    }
}