using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boss001
{
    public class BaseBindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value,
                          [CallerMemberName] string propertyName = null)
        {
            bool isSetted = false;

            this.OnPropertyChanged(propertyName);
            isSetted = !string.IsNullOrEmpty(propertyName);

            return isSetted;
        }

        protected void OnPropertyChanged<T>(
                          Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body;
            MemberExpression member = body as MemberExpression;

            PropertyInfo info = member.Member as PropertyInfo;

            this.OnPropertyChanged(info.Name);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
