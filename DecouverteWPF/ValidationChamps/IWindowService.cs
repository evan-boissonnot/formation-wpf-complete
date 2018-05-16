using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss001
{
    public interface IWindowService 
    {
        void Show(BaseBindable viewModel);
    }
}
