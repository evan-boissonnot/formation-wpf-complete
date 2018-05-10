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

namespace ExempleDonneesLiees
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Droide _droide = new Droide()
        {
            Id = 1,
            Name = "test robot"
        };
        private Droide _droide2 = new Droide2()
        {
            Id = 1,
            Name = "test robot"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private string _testLabel = string.Empty;

        /// <summary>
        ///  Est null tant qu'aucun binding niveau vue
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public string TestLabel
        {
            get => this._testLabel;
            set
            {
                this._testLabel = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestLabel"));
            }
        }

        public Droide Droide { get => this._droide; set => this._droide = value; }
        public Droide Droide2 { get => this._droide2; set => this._droide2 = value; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Droide.Name = "test 2";
            this.Droide2.Name = "test 2";
        }
    }
}
