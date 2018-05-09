using GalaSoft.MvvmLight;
using MvvmLight1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvvmLight1.Model
{
    public class ObservableActivity : ObservableObject, ICoordinate
    {
        #region Fields
        private static Random __rand = new Random();
        private IActivity _item = null;
        private bool _isMoving = false;
        private Thread _currentThread = null;
        #endregion

        #region Constructors
        public ObservableActivity(IActivity model)
        {
            this._item = model;
            this._currentThread = new Thread(new ThreadStart(() => this.DoStart()));
        }
        #endregion

        #region Public methods
        public void Start()
        {
            this._currentThread.Start();
        }

        public void Stop()
        {
            this._isMoving = false;
            this._currentThread.Abort();
        }
        #endregion

        #region Internal methods
        private void DoStart()
        {
            this._isMoving = true;

            while (this._isMoving)
            {
                int val = __rand.Next(0, 2);
                int min = __rand.Next(-1, 1);
                int valMovment = __rand.Next(min, 2);

                this.X += (valMovment);
                this.Y += (valMovment);


                System.Threading.Thread.Sleep(100);
            }
        }
        #endregion

        #region Properties
        public double X
        {
            get => this._item.Coordinate.X;
            set
            {
                this._item.Coordinate.X = value;
                this.RaisePropertyChanged(() => this.X);
            }
        }

        public double Y
        {
            get => this._item.Coordinate.Y;
            set
            {
                this._item.Coordinate.Y = value;
                this.RaisePropertyChanged(() => this.Y);
            }
        }
        #endregion
    }
}
