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
        private readonly IDataService _dataService;
        private ICommand _launchCommand = null;
        private BackgroundWorker _worker = new BackgroundWorker();

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        private void LaunchProgram()
        {
            this._worker.RunWorkerAsync();
        }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
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

                    WelcomeTitle = item.Title;
                });

            this.LaunchCommand = new RelayCommand(LaunchProgram);
            this._worker.DoWork += this._worker_DoWork;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rand = new Random();
            while (true)
            {
                this.TranslateX = rand.Next(0, 300);
                Thread.Sleep(100);
            }
        }

        private double _translateX = 50;

        public double TranslateX
        {
            get => this._translateX;
            set
            {
                this._translateX = value;
                this.RaisePropertyChanged("TranslateX");
            }
        }

        public ICommand LaunchCommand { get => this._launchCommand; set => this._launchCommand = value; }


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}