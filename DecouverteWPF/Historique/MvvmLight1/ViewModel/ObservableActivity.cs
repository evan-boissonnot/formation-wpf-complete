using GalaSoft.MvvmLight;
using MvvmLight1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.ViewModel
{
    public class ObservableActivity : ObservableObject, ICoordinate
    {
        #region Fields
        private double _x;
        private double _y;
        private IActivity _item = null;
        #endregion

        #region Constructors
        public ObservableActivity(IActivity model)
        {
            this._item = model;

            this.X = this._item.Coordinate.X;
            this.Y = this._item.Coordinate.Y;
        }
        #endregion

        #region 
        public double X
        {
            get => this._x;
            set
            {
                this._x = value;
                this.RaisePropertyChanged("X");
            }
        }

        public double Y
        {
            get => this._y;
            set
            {
                this._y = value;
                this.RaisePropertyChanged("Y");
            }
        }
        #endregion
    }
}
