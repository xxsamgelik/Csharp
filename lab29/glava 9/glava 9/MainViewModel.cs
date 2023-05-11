using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace glava_9
{
    public class DisplayViewModel : INotifyPropertyChanged
    {
        Person person;
        public event PropertyChangedEventHandler? PropertyChanged;
        public DisplayViewModel(Person person) => this.person = person;
        public string Name
        {
            get => person.Name;
            set
            {
                if (person.Name != value)
                {
                    person.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Age
        {
            get => person.Age;
            set
            {
                if (person.Age != value)
                {
                    person.Age = value;
                    OnPropertyChanged();
                }
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class EditViewModel : INotifyPropertyChanged
    {
        string name = "";
        int age;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class MainViewModel
    {
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public DisplayViewModel Person { get; set; }
        public EditViewModel EditData { get; set; }

        public MainViewModel()
        {
            Person = new DisplayViewModel(new Person("Tom", 38));
            EditData = new EditViewModel();
            SaveCommand = new Command(() =>
            {
                Person.Name = EditData.Name;
                Person.Age = EditData.Age;
                EditData.Name = "";
                EditData.Age = 0;
            });
            EditCommand = new Command(() =>
            {
                EditData.Name = Person.Name;
                EditData.Age = Person.Age;
            });
        }
    }   
}
