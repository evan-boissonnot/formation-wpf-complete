using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace ListOfTemplates
{
    //https://msdn.microsoft.com/en-us/library/aa970773%28v=VS.85%29.aspx

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            this.LoadTypes();
        }
        #endregion

        #region Internal methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoadTypes()
        {
            Type controlType = typeof(Control);
            Assembly assembly = Assembly.GetAssembly(controlType);

            this.ListOfTypes = assembly.GetTypes().Where(item => item.IsSubclassOf(controlType) && 
                                                                 !item.IsAbstract && 
                                                                 item.IsPublic)
                                                  .ToList();

            this.ObservableListOfTypes = new ObservableCollection<Type>(this.ListOfTypes);
        }
        #endregion

        #region Properties
        public List<Type> ListOfTypes { get; set; }

        public ObservableCollection<Type> ObservableListOfTypes
        {
            get;set;
        }
        #endregion
    }
}
