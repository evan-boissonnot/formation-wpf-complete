using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Boss001
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private Droide _droide = new Droide();
        private Random _rand = new Random();
        private BackgroundWorker _worker = new BackgroundWorker();
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            this._worker.WorkerSupportsCancellation = true;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += this._worker_DoWork;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Droide.Move(this._rand.Next);
        }
        #endregion

        #region Internal methods
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._worker.RunWorkerAsync();
        }
        #endregion

        #region Properties
        public Droide Droide { get => this._droide; set => this._droide = value; }
        #endregion
    }
}
