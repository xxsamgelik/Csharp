using System.Collections.ObjectModel;

namespace glava8;

class StartPage : ContentPage
{
    public ObservableCollection<User> Users { get; set; }
    Entry nameEntry, ageEntry;

    public StartPage()
    {
        // определяем данные
        Users = new ObservableCollection<User>
        {
            new User {Name="Tom", Age=38 },
            new User {Name = "Bob", Age = 42}
        };
        ListView listView = new ListView();
        // определяем источник данных
        listView.ItemsSource = Users;
        // определяем шаблон данных
        listView.ItemTemplate = new DataTemplate(() =>
        {
            // привязка к свойству Name
            Label nameLabel = new Label { FontSize = 16 };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            // привязка к свойству Age
            Label ageLabel = new Label { FontSize = 14 };
            ageLabel.SetBinding(Label.TextProperty, "Age");

            // создаем объект ViewCell.
            return new ViewCell
            {
                View = new StackLayout
                {
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Vertical,
                    Children = { nameLabel, ageLabel }
                }
            };
        });

        // поля для добавления нового объекта User
        nameEntry = new Entry { Placeholder = "Enter name", Margin = 5 };
        ageEntry = new Entry { Placeholder = "Enter age", Margin = 5 };
        Button saveButton = new Button { Text = "Save", WidthRequest = 100, Margin = 5, HorizontalOptions = LayoutOptions.Start };
        saveButton.Clicked += SaveButton_Clicked;
        StackLayout form = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Children = { nameEntry, ageEntry, saveButton }
        };
        Content = new StackLayout { Children = { form, listView }, Padding = 7 };
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        int.TryParse(ageEntry.Text, out var age);
        Users.Add(new User { Name = nameEntry.Text, Age = age });
        nameEntry.Text = ageEntry.Text = "";
    }
}