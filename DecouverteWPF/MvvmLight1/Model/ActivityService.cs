using System;
using System.Collections.Generic;

namespace MvvmLight1.Model
{
    public class ActivityService : IActivityService
    {
        #region Public methods
        public void GetData(Action<IActivity, Exception> callback)
        {
            callback(null, null);
        }

        public void GetList(Action<List<IActivity>, Exception> callback)
        {
            callback(new List<IActivity>()
            {
                new Human()
                {
                    Coordinate = new DefaultCoordinate()
                    {
                        X = 10,
                        Y = 10
                    }
                },
                new Human()
                {
                    Coordinate = new DefaultCoordinate()
                    {
                        X = 20,
                        Y = 20
                    }
                }
            }, null);
        }
        #endregion
    }
}