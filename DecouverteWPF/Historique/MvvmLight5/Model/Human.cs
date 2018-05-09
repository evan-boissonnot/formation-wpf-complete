using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    public class Human : IActivity
    {
        #region Fields
        private string _id = string.Empty;
        #endregion

        #region Constructors
        public Human()
        {
            this._id = Guid.NewGuid().ToString();
        }
        #endregion

        #region Properties
        public string Id { get => this._id; }

        public ICoordinate Coordinate { get; set; }
        #endregion
    }
}
