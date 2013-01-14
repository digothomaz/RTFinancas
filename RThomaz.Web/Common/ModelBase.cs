namespace RThomaz.Web.Common
{
    public abstract class ModelBase
    {
        private readonly string _title;
        private readonly string _controllerName;

        public ModelBase(string title, string controllerName)
            : base()
        {
            _title = title;
            _controllerName = controllerName;
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string ControllerName
        {
            get
            {
                return _controllerName;
            }
        }
    }
}