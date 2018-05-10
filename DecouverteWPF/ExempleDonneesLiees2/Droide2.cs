using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDonneesLiees
{
    public class Droide2 : Droide, INotifyPropertyChanged
    {
        private int _id;
        private string _name;

        public override int Id
        {
            get => this._id;
            set
            {
                this._id = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }

        public override string Name
        {
            get => this._name;
            set
            {
                this._name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
