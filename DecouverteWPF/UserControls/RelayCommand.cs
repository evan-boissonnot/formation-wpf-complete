using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boss001
{
    public class RelayCommand : ICommand
    {
        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Fields
        private EventHandler _action = null;
        #endregion

        #region Constructors
        public RelayCommand(EventHandler action)
        {
            this._action = action;
        }
        #endregion

        #region Public methods
        public bool CanExecute(object parameter)
        {
            // Ici, on peut ajouter les règles de validation de l'exécution
            return true;
        }

        public void Execute(object parameter)
        {
            this._action?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
