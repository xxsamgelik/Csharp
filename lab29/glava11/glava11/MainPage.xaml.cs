using System.Collections.ObjectModel;

namespace glava11;

public partial class MainPage : ContentPage
{
    // список групп, к которым идет привязка
    public ObservableCollection<Grouping<string, Person>> PeopleGroups { get; set; }
    public MainPage()
    {
        InitializeComponent();

        // начальные данные
        var people = new List<Person>
        {
                new Person {Name="Tom", Company="Microsoft" },
                new Person {Name="Sam", Company="Google" },
                new Person {Name="Alice", Company="Microsoft" },
                new Person {Name="Bob", Company="JetBrains" },
                new Person {Name="Kate", Company="Google" },
        };
        // получаем группы
        var groups = people.GroupBy(p => p.Company).Select(g => new Grouping<string, Person>(g.Key, g));
        // передаем группы в PeopleGroups
        PeopleGroups = new ObservableCollection<Grouping<string, Person>>(groups);
        BindingContext = this;
    }
}

