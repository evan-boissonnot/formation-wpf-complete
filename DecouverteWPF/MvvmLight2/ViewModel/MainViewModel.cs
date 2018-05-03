using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.Model;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

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

        #region Commands
        private ICommand _launchCommand = null;
        private ICommand _clickCommand = null;
        #endregion

        private BackgroundWorker _worker = new BackgroundWorker();

        private double _translateX = 50;
        private double _translateY = 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IActivityService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }
                });

            this.Initialize();

            this._worker.DoWork += this._worker_DoWork;
        }
        #endregion

        #region Internal methods
        private void Initialize()
        {
            this.ManageCommands();
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
            while (true)
            {
                int val = rand.Next(0, 2);
                int min = rand.Next(-1, 1);
                int valMovment = rand.Next(min, 2);

                if (val == 0)
                    this.TranslateX += valMovment;
                else
                    this.TranslateY += valMovment;

                Thread.Sleep(100);
            }
        }
        #endregion
        #endregion

        #region Properties
        public double TranslateX
        {
            get => this._translateX;
            set
            {
                this._translateX = value;
                this.RaisePropertyChanged("TranslateX");
            }
        }

        public double TranslateY
        {
            get => this._translateY;
            set
            {
                this._translateY = value;
                this.RaisePropertyChanged("TranslateY");
            }
        }

        public ICommand ClickCommand { get => this._clickCommand; set => this._clickCommand = value; }

        public ICommand LaunchCommand { get => this._launchCommand; set => this._launchCommand = value; }
        #endregion




        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}