using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMHierarchiesDemo.Models;

namespace MVVMHierarchiesDemo.ViewModels
{
    public class DisplayViewModel : INotifyPropertyChanged
    {
        // Properties
        public MainViewModel MyMainViewModel { get; }

        // Constructor
        public DisplayViewModel(MainViewModel mvm)
        {
            MyMainViewModel = mvm;
        }

        // Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
