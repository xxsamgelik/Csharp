namespace glava12;

public partial class PersonPage : ContentPage
{
    bool edited = true; // ���� ��������������
    // �����������/������������� ������������
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

        // ���� ����������
        if (edited == false)
        {
            if (Application.Current?.MainPage is NavigationPage navPage)
            {
                // ���� ���������
                IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                // ���������� ������� � �����
                int pageCount = navPage.Navigation.NavigationStack.Count;
                // ������� � ����� ���������� �������� - �� ���� MainPage
                if (navStack[pageCount - 1] is MainPage mainPage)
                {
                    // �������� � ������� �������� ����� AddPerson ��� ����������
                    mainPage.AddPerson(Person);
                }
            }
        }
    }
}