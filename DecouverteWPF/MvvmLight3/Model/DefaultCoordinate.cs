using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    public class DefaultCoordinate : ICoordinate
    {
        #region Properties
        public double X { get; set; }

        public double Y { get; set; }
        #endregion
    }
}
