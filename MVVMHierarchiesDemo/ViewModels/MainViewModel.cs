using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMHierarchiesDemo.Models;
using MVVMHierarchiesDemo.Misc;

namespace MVVMHierarchiesDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Properties
        public ObservableCollection<Person> People { get; set; }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                RaisePropertyChanged(nameof(SelectedPerson));
            }
        }

        private object leftViewModel;
        public object LeftViewModel
        {
            get { return leftViewModel; }
            set { leftViewModel = value; RaisePropertyChanged(nameof(LeftViewModel)); }
        }

        private object rightViewModel;
        public object RightViewModel
        {
            get { return rightViewModel; }
            set { rightViewModel = value; RaisePropertyChanged(nameof(RightViewModel)); }
        }

        public MyICommand SwapView { get; set; }


        // Constructor
        public MainViewModel()
        {
            People = new ObservableCollection<Person>();

            Person Josh = new Person("Josh");
            Josh.Age = 23;

            Person Gabriella = new Person("Gabriella");
            Gabriella.Age = 24;
            Gabriella.Birthday = new DateTime(1995, 04, 03);

            Person Someone = new Person("Someone");
            Someone.Age = 13;

            People.Add(Josh);
            People.Add(Gabriella);
            People.Add(Someone);

            SelectedPerson = People[new Random().Next(People.Count - 1)];
            LeftViewModel = new EditViewModel(this);
            RightViewModel = new DisplayViewModel(this);

            SwapView = new MyICommand(OnSwapView, CanSwapView);
        }

        // Methods
        public void OnSwapView()
        {
                var tl = LeftViewModel;
                var tr = RightViewModel;
                LeftViewModel = tr;
                RightViewModel = tl;
        }

        public bool CanSwapView()
        {
            return SelectedPerson != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
