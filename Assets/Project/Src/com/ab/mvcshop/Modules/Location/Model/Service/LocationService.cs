using com.ab.mvcshop.core.command;
using com.ab.mvcshop.core.localization;
using com.ab.mvcshop.core.mvc;
using com.ab.mvcshop.core.playerdata;
using Rx = R3;


namespace com.ab.mvcshop.modules.location
{
    public class LocationService : ILocationService
    {
        readonly IPlayerDataService _persistent;
        readonly INotifyModelService _notifyModel;
        readonly ILocalizationService _localization;

        readonly Rx.BehaviorSubject<Location> _model;
        public Rx.Observable<Location> ModelChanged => _model;

        public LocationService(
            CommandInvoker commandInvoker,
            INotifyModelService notifyModel,
            IPlayerDataService persistent,
            ILocalizationService localization)
        {
            _persistent = persistent;
            _notifyModel = notifyModel;
            _localization = localization;
            _persistent.Init<Location>();
            
            Location persistRef = _persistent.Get<Location>();
            _model = new Rx.BehaviorSubject<Location>(persistRef);

            commandInvoker.Registry(typeof(Location), this);
        }
        
        public string Title => _localization.GetString(_model.Value.Title);

        public string TitleLk
        {
            get => _model.Value.Title;
            private set
            {
                if (value == _model.Value.Title) return;

                _model.Value.Title = value;
                _model.OnNext(_model.Value);
                _notifyModel.OnChange();
            }
        }

        public void ChangeAmount(string valueToChange) =>
            UpdateAmount(valueToChange);

        void UpdateAmount(string title)
        {
            Location location = new(title);
            _model.OnNext(location);
            _persistent.CommitAsync(location);
        }

        public bool CanExecute(CommandContext ctx, IModel model)
        {
            var loation = (Location)model;
            var execute = _model.Value.Title == loation.Title;
            return execute;
        }
    }
}