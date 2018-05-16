using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss001
{
    public class MasterDetailWindowService : IWindowService
    {
        #region Public properties
        public void Show(BaseBindable viewModel)
        {
            DroideMasterWindow window = new DroideMasterWindow();

            window.Show();
        }
        #endregion
    }
}
