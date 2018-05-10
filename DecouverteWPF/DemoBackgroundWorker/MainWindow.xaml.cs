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

namespace DemoBackgroundWorker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<long> _list = new List<long>();
        private BackgroundWorker _worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            this._worker.WorkerSupportsCancellation = true;
            this._worker.WorkerReportsProgress = true;
            this._worker.ProgressChanged += this._worker_ProgressChanged;
            this._worker.RunWorkerCompleted += this._worker_RunWorkerCompleted;
            this._worker.DoWork += this._worker_DoWork;
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                this.lblState.Content = "Opération annulée";
            else
            {
                this.lstResult.ItemsSource = e.Result as List<long>;
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbWorking.Value = e.ProgressPercentage;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            long result = this.ComputeFibonacci(90, e);

            // this.lstResult.ItemsSource = this._list;

            // Si on veut afficher durant le calcul
            //this.Dispatcher.Invoke(() =>
            //{
            //    this.lstResult.ItemsSource = ;
            //});

            e.Result = this._list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._worker.RunWorkerAsync();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this._worker.CancelAsync();
        }

        private long ComputeFibonacci(long value, DoWorkEventArgs e)
        {
            long result = 0;
            long previous = 0;
            long next = 1;

            for (long i = 0; i < value && !this._worker.CancellationPending; i++)
            {
                decimal pourcent = ((decimal)i / (decimal)value) * 100;
                this._worker.ReportProgress((int)pourcent);

                result = previous + next;
                previous = next;
                next = result;

                this._list.Add(result);

                System.Threading.Thread.Sleep(100);
            }
            if(!this._worker.CancellationPending)
                this._worker.ReportProgress(100);

            e.Cancel = this._worker.CancellationPending;

            return result;
        }
    }
}
