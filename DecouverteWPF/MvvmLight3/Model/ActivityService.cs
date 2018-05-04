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
            List<IActivity> list = new List<IActivity>();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Human()
                {
                    Coordinate = new DefaultCoordinate()
                    {
                        X = rand.Next(0, 300),
                        Y = rand.Next(0, 300)
                    }
                });
            }

            callback(list, null);
        }
        #endregion
    }
}