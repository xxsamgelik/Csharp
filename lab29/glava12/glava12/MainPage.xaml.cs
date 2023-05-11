using System.Collections.ObjectModel;

namespace glava12;

public partial class MainPage : ContentPage
{
    ObservableCollection<Person> People { get; set; }

    public MainPage()
    {
        InitializeComponent();

        People = new ObservableCollection<Person>
        {
            new Person {Name="Tom", Age = 38},
            new Person {Name="Bob", Age = 42},
            new Person {Name="Sam", Age = 25},
        };
        peopleList.BindingContext = People;
    }
    // обработчик выбора элемента в списке
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
    {
        // Получаем выбранный элемент
        if (args.SelectedItem is Person selectedPerson)
        {
            // Снимаем выделение
            peopleList.SelectedItem = null;
            // Переходим на страницу редактирования элемента 
            await Navigation.PushAsync(new PersonPage(selectedPerson));
        }
    }
    // переходим на страницу PersonPage для добавления нового элемента
    async void AddButton_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonPage(null));
    }
    // вспомогательный метод для добавления элемента в список
    protected internal void AddPerson(Person phone)
    {
        People.Add(phone);
    }
}

