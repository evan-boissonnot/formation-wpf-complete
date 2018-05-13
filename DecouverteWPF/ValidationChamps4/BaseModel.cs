using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boss001
{
    public abstract class BaseModel : BaseBindable, INotifyDataErrorInfo/*, IDataErrorInfo, INotifyDataErrorInfo*/
    {
        #region Events
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion

        #region Fields
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        #endregion

        #region Public methods
        public IEnumerable GetErrors(string propertyName)
        {
            return this._errors.Where(item => item.Key == propertyName).Select(item => item.Value).FirstOrDefault();
        }
        #endregion

        #region Internal methods
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(propertyName, null);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null, Func<Exception> validProperty = null)
        {
            base.OnPropertyChanged(propertyName);

            Exception ex = validProperty?.Invoke();
            if (ex == null)
                this._errors.Remove(propertyName);
            else
                this.AddNewError(propertyName, ex.Message);

            this.NotifyErrorsChanged(propertyName);
        }

        private void AddNewError(string propertyName, string error)
        {
            if(!this._errors.Any(item => item.Key == propertyName))
                this._errors.Add(propertyName, new List<string>());

            var errorItem = this._errors.FirstOrDefault(item => item.Key == propertyName);

            errorItem.Value.Add(error);
        }

        protected virtual void NotifyErrorsChanged([CallerMemberName] string propertyName = null)
        {
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        #endregion

        #region Properties
        public bool HasErrors => this._errors.Values.Any(item => item.Count > 0);
        #endregion
    }
}
