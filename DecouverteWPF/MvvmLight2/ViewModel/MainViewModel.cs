using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly IActivityService _dataService;
        private ObservableCollection<Model.ObservableActivity> _activityList = null;

        #region Commands
        private ICommand _launchCommand = null;
        private ICommand _clickCommand = null;
        #endregion

        private BackgroundWorker _worker = new BackgroundWorker();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IActivityService dataService)
        {
            this._dataService = dataService;

            this.Initialize();
            this._worker.DoWork += this._worker_DoWork;
        }
        #endregion

        #region Internal methods
        private void Initialize()
        {
            this.ManageCommands();
            this.LoadButtons();
        }

        private void LoadButtons()
        {
            this._dataService.GetList(
                (list, error) =>
                {
                    if (error == null)
                    {
                        List<ObservableActivity> activityList = list.Select(item => new ObservableActivity(item)).ToList();
                        this.ActivityList = new ObservableCollection<ObservableActivity>(activityList);
                    }
                });
        }

        private void ManageCommands()
        {
            this.LaunchCommand = new RelayCommand(LaunchProgram);
            this.ClickCommand = new RelayCommand(ClickOnButton);
        }

        private void LaunchProgram()
        {
            this._worker.RunWorkerAsync();
        }

        private void ClickOnButton()
        {

        }

        #region Event methods
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();

            foreach (var item in this.ActivityList)
            {
                Thread thread = new Thread(new ThreadStart(() => item.Start()));
                thread.Start();
            }
        }
        #endregion
        #endregion

        #region Properties
        public ObservableCollection<Model.ObservableActivity> ActivityList
        {
            get => this._activityList;
            set
            {
                this._activityList = value;
                this.RaisePropertyChanged(() => this.ActivityList);
            }
        }

        public ICommand ClickCommand { get => this._clickCommand; set => this._clickCommand = value; }

        public ICommand LaunchCommand { get => this._launchCommand; set => this._launchCommand = value; }
        #endregion
    }
}