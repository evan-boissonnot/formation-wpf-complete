using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss001
{
    public class Droide : BaseBindable
    {
        #region Fields
        private double _x = 0;
        private double _y = 0;
        private Func<int, int, int> _nextValue = null;
        #endregion

        #region Constructors
        public Droide(Func<int, int, int> nextValue)
        {
            this._nextValue = nextValue;
        }
        #endregion

        #region Public methods
        public void Move()
        {
            while (true)
            {
                double lastX = this.X;
                double lastY = this.Y;

                this.X = lastX + this._nextValue(-1, 2);
                this.Y = lastY + this._nextValue(-1, 2);

                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region Properties
        public double X { get => this._x; set { this._x = value; this.OnPropertyChanged(() => this.X); } }

        public double Y { get => this._y; set { this._y = value; this.OnPropertyChanged(); } }
        #endregion
    }
}
