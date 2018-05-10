using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boss001
{
    public class MainWindowViewModel : BaseBindable
    {
        #region Fields
        private Droide _droide = new Droide();
        private Random _rand = new Random();
        private BackgroundWorker _worker = new BackgroundWorker();

        #region Commands
        private ICommand _launchProgramCommand = null;
        #endregion
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            this.LaunchProgramCommand = new RelayCommand(this.LaunchProgram);

            this._worker.WorkerSupportsCancellation = true;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += this._worker_DoWork;
        }
        #endregion

        #region Internal methods
        private void LaunchProgram(object sender, EventArgs e)
        {
            this._worker.RunWorkerAsync();
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Droide.Move(this._rand.Next);
        }
        #endregion

        #region Properties
        public Droide Droide { get => this._droide; set => this._droide = value; }

        public ICommand LaunchProgramCommand { get => this._launchProgramCommand; set => this._launchProgramCommand = value; }
        #endregion
    }
}
