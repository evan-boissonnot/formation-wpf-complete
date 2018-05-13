using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss001
{
    public class Droide : BaseModel
    {
        #region Fields
        private int _id = 0;
        private string _name = string.Empty;
        private double _x = 0;
        private double _y = 0;
        private Func<int, int, int> _nextValue = null;
        #endregion

        #region Constructors
        public Droide() { }

        public Droide(Func<int, int, int> nextValue) : this()
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

        public string Name { get => this._name; set { this._name = value; throw new Exception("Champ invalide"); this.OnPropertyChanged(); } }
        public int Id { get => this._id; set { this._id = value; this.OnPropertyChanged(); } }
        #endregion
    }
}
