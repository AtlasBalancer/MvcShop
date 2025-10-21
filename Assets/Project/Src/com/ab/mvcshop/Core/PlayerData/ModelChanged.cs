namespace com.ab.mvcshop.core.playerdata
{
    public class ModelChanged<TModel> 
    {
        TModel _oldModel;
        TModel _newModel;

        public ModelChanged(TModel oldModel, TModel newModel)
        {
            _oldModel = oldModel;
            _newModel = newModel;
        }
    }
}