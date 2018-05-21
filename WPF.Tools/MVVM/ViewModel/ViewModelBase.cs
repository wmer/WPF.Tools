using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Tools.MVVM.ViewModel {
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property) =>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
