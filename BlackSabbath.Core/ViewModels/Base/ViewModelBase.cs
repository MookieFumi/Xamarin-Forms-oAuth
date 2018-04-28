using System;
using System.ComponentModel;

namespace BlackSabbath.Core.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
