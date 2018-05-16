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
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();

            ((MainWindowViewModel)this.DataContext).WindowService = new MasterDetailWindowService();
        }
        #endregion

        #region Internal methods
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this._worker.RunWorkerAsync();
        }
        #endregion
    }
}
