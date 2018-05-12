using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boss001
{
    public class DroideMasterViewModel : BaseBindable
    {
        #region Fields
        private Droide _selectedDroide = null;
        private bool _isPanelVisible = false;
        #endregion

        #region Constructors
        public DroideMasterViewModel()
        {
            this.SaveDroideCommand = new RelayCommand(this.SaveDroide);
            this.NewDroideCommand = new RelayCommand(this.PrepareNewDroide);
            this.CancelSaveDroideCommand = new RelayCommand(this.CancelSavingDroide);

            this.SelectedDroide = null;
            this.DroideList = new ObservableCollection<Droide>();
        }
        #endregion

        #region Public methods
        public void SaveDroide(object sender, EventArgs e)
        {
            bool isAddingdroide = this.SelectedDroide.Id <= 0;

            this.DroideList.Add(this.SelectedDroide);

            if (isAddingdroide)
                this.SelectedDroide = new Droide();
        }

        public void PrepareNewDroide(object sender, EventArgs e)
        {
            this.SelectedDroide = new Droide();
        }

        public void CancelSavingDroide(object sender, EventArgs e)
        {
            this.SelectedDroide = null;
        }
        #endregion

        #region Properties
        public Droide SelectedDroide
        {
            get => this._selectedDroide;
            set
            {
                this._selectedDroide = value;
                this.OnPropertyChanged(() => this.SelectedDroide);
                this.IsPanelVisible = value != null;
            }
        }

        public bool IsPanelVisible
        {
            get => this._isPanelVisible;
            set
            {
                this._isPanelVisible = value;
                this.OnPropertyChanged(() => this.IsPanelVisible);
            }
        }

        public ObservableCollection<Droide> DroideList { get; set; }

        public ICommand SaveDroideCommand { get; set; }
        public ICommand NewDroideCommand { get; set; }
        public ICommand CancelSaveDroideCommand { get; set; }
        #endregion
    }
}
