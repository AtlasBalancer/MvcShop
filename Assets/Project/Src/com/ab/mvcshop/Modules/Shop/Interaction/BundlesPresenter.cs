using System.Collections.Generic;
using R3;
using Bundle = com.ab.mvcshop.modules.shop.model.Bundle;

namespace com.ab.mvcshop.modules.shop
{
    public class BundlesPresenter
    {
        public readonly Dictionary<int, BundleEntry> Refs;

        public readonly Subject<int> BuyClick;
        public BundlesPresenter()
        {
            Refs = new();
            BuyClick = new();
        }

        public Bundle GetBundle(int bundleId)
        {
            return Refs[bundleId].Bundle;
        }

        public void Add(Bundle bundle, BundleView view)
        {
            view.Buy.onClick.AddListener(() => BuyClick.OnNext(bundle.Id));
            Refs.Add(bundle.Id, new BundleEntry(bundle, view));
        }

        public class BundleEntry
        {
            public readonly Bundle Bundle;
            public readonly BundleView View;

            public BundleEntry(Bundle bundle, BundleView view)
            {
                Bundle = bundle;
                View = view;
            }
        }
    }
}