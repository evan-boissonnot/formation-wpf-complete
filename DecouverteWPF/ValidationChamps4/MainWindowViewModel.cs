using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Boss001
{
    public class MainWindowViewModel : BaseBindable
    {
        #region Fields
        private Random _rand = new Random();
        private BackgroundWorker _worker = new BackgroundWorker();
        private List<Thread> _threads = new List<Thread>();

        #region Commands
        private ICommand _launchProgramCommand = null;
        private ICommand _closeCommand = null;
        private ICommand _showMasterCommand = null;
        #endregion
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            this.Initialize();
        }
        #endregion

        #region Internal methods
        private void Initialize()
        {
            this.LoadDroides();

            this.LaunchProgramCommand = new RelayCommand(this.LaunchProgram);
            this.CloseCommand = new RelayCommand(this.Close);
            this.ShowMasterCommand = new RelayCommand(this.ShowMaster);

            this._worker.WorkerSupportsCancellation = true;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += this._worker_DoWork;
        }

        private void LoadDroides()
        {
            const int MAX_X = 1500;
            const int MAX_Y = 800;

            this.DroideList = new ObservableCollection<Droide>();

            int maxDroide = this._rand.Next(10, 100);

            for (int i = 0; i < maxDroide; i++)
                this.DroideList.Add(new Droide(this._rand.Next)
                {
                    X = this._rand.Next(0, MAX_X),
                    Y = this._rand.Next(0, MAX_Y)
                });
        }

        private void LaunchProgram(object sender, EventArgs e)
        {
            this._worker.RunWorkerAsync(this._rand);
        }

        private void ShowMaster(object sender, EventArgs e)
        {
            this.WindowService.Show(null);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in this.DroideList)
            {
                Thread thread = new Thread(new ThreadStart(item.Move));
                this._threads.Add(thread);

                thread.Start();
            }

            //this.DroideList.AsParallel().ForAll(item => item.Move(this._rand.Next));

        }

        private void Close(object sender, EventArgs e)
        {
            this._threads.ForEach(item => item.Abort());
        }
        #endregion

        #region Properties
        public ICommand LaunchProgramCommand { get => this._launchProgramCommand; set => this._launchProgramCommand = value; }
        public ICommand CloseCommand { get => this._closeCommand; set => this._closeCommand = value; }
        public ICommand ShowMasterCommand { get => this._showMasterCommand; set => this._showMasterCommand = value; }

        public IWindowService WindowService
        {
            get;set;
        }

        public ObservableCollection<Droide> DroideList { get; set; }
        #endregion
    }
}
