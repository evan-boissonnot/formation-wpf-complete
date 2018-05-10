﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
            
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}