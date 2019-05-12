using MVVMHierarchiesDemo.Misc;
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
        public MainViewModel MyMainViewModel { get; }
        public MyICommand ClickerClicked { get; set; }

        // Constructor
        public EditViewModel(MainViewModel mvm)
        {
            MyMainViewModel = mvm;
            ClickerClicked = new MyICommand(OnClickerClicked, CanClickClicker);
        }

        // Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void OnClickerClicked()
        {
            MyMainViewModel.SelectedPerson.ClickerCount += 1;
        }

        public bool CanClickClicker()
        {
            return true;
        }
    }
}
