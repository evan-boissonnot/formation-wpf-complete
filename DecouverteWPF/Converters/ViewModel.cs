using Boss001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters
{
    public class ViewModel : BaseBindable
    {
        private bool _isVisible = false;

        public bool IsVisible { get => this._isVisible; set { this._isVisible = value; this.OnPropertyChanged(); } }
    }
}
