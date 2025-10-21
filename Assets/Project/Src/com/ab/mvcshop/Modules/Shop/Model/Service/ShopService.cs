using System;
using System.Collections.Generic;
using System.Linq;
using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.localization;
using com.ab.mvcshop.core.playerdata;
using com.ab.mvcshop.modules.shop.definition;
using R3;

namespace com.ab.mvcshop.modules.shop.model
{
    public class ShopService : IShopService
    {
        readonly Settings _settings;
        readonly List<Bundle> _bundles;

        readonly ICommandService _command;

        readonly ILocalizationService _localization;
        readonly INotifyModelService _notifyModel;

        public Observable<Unit> ModelChanged => _notifyModel.Changed;

        public ShopService(
            ICommandService command,
            Settings settings,
            INotifyModelService notifyModel,
            ILocalizationService localization)
        {
            _command = command;
            _settings = settings;
            _localization = localization;
            _bundles = InitBundles(settings.BundleList);
            _notifyModel = notifyModel;
        }

        List<Bundle> InitBundles(BundleListSo bundlesDef)
        {
            List<Bundle> bundles = new();

            foreach (var (item, index) in bundlesDef.Bundles.Select((item, index) => (item, index)))
            {
                CommandCostComposite conditions =
                    _command.CastSoToCommandCostAction(item.Conditions);

                CommandCostComposite results =
                    _command.CastSoToCommandCostAction(item.Results);

                string message = _localization.GetString(item.MessageLK);

                Bundle bundle = new Bundle(index, conditions, results, message);
                bundles.Add(bundle);
            }

            return bundles;
        }

        public void BuyBundle(Bundle bundle)
        {
            _command.Execute(bundle.Conditions.Executions);
            _command.Execute(bundle.Results.Executions);
        }

        public List<Bundle> GetBundles() =>
            _bundles;

        [Serializable]
        public class Settings
        {
            public BundleListSo BundleList;
        }
    }
}