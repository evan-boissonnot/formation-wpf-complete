using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace DecouverteWPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.LoadedCommand = new RelayCommand(this.WindowsLoaded);
        }

        #region Internal methods
        private void WindowsLoaded()
        {
            this.ButtonHeight = 20;
            this.ButtonWidth = 20;
        }
        #endregion

        #region Properties
        public double ButtonWidth { get; set; }

        public double ButtonHeight { get; set; }

        public ICommand LoadedCommand { get; set; }
        #endregion
    }
}