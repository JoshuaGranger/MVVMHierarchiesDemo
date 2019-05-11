using MVVMHierarchiesDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHierarchiesDemo.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        // Properties

        // Constructor
        public EditViewModel()
        {
        }

        // Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
