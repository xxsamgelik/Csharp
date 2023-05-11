namespace glava12;

public partial class PersonPage : ContentPage
{
    bool edited = true; // флаг редактирования
    // добавляемый/редактируемый пользователь
    Person Person { get; set; }
    public PersonPage(Person? person)
    {
        InitializeComponent();

        if (person is null)
        {
            Person = new Person();
            edited = false;
        }
        else
        {
            Person = person;
        }
        BindingContext = Person;
    }

    async void SavePerson(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

        // если добавление
        if (edited == false)
        {
            if (Application.Current?.MainPage is NavigationPage navPage)
            {
                // стек навигации
                IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                // количество страниц в стеке
                int pageCount = navPage.Navigation.NavigationStack.Count;
                // находим в стеке предыдущую страницу - то есть MainPage
                if (navStack[pageCount - 1] is MainPage mainPage)
                {
                    // вызываем у главной страницы метод AddPerson для добавления
                    mainPage.AddPerson(Person);
                }
            }
        }
    }
}