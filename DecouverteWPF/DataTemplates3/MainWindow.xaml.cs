using CollectionsVisu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Collections
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Droide> _list = new ObservableCollection<Droide>();

        public MainWindow()
        {
            InitializeComponent();
            this.lstIems.ItemsSource = this.List;
            this.lstIems2.ItemsSource = this.List;
        }

        public ObservableCollection<Droide> List { get => this._list; set => this._list = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.List.Add(new Droide() { Name = "Robot" + DateTime.Now.Ticks });
        }
    }
}
