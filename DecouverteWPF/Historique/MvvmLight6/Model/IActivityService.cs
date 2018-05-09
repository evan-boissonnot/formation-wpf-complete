using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1.Model
{
    public interface IActivityService
    {
        void GetList(Action<List<IActivity>, Exception> callback);

        void GetData(Action<IActivity, Exception> callback);
    }
}
