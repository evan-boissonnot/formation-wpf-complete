using System;
using System.Collections.Generic;
using MvvmLight1.Model;

namespace MvvmLight1.Design
{
    public class DesignDataService : IActivityService
    {
        #region Public methods
        public void GetData(Action<IActivity, Exception> callback)
        {
            callback(null, null);
        }

        public void GetList(Action<List<IActivity>, Exception> callback)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}