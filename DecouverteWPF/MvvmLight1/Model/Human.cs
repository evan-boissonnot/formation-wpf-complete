using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    public class Human : IActivity
    {
        #region Properties
        public ICoordinate Coordinate { get; set; }
        #endregion
    }
}
