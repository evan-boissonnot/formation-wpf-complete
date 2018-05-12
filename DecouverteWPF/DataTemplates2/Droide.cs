using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsVisu
{
    public class Droide : BaseBindable
    {
        #region Fields
        private Random _rand = new Random();
        private double _x = 0;
        private double _y = 0;
        #endregion

        #region Public methods
        public void Move(Func<int,int, int> nextValue)
        {
            while (true)
            {
                double lastX = this.X;
                double lastY = this.Y;

                this.X = lastX + nextValue(-1, 2);
                this.Y = lastY + nextValue(-1, 2);

                System.Threading.Thread.Sleep(100);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} => {this.X}.{this.Y}";
        }
        #endregion

        #region Properties
        public double X { get => this._x; set { this._x = value; this.OnPropertyChanged(() => this.X); } }

        public double Y { get => this._y; set { this._y = value; this.OnPropertyChanged(); } }

        public string Name { get; set; }
        #endregion
    }
}
