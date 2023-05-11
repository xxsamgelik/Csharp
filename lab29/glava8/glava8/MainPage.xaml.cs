using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace glava8;

public partial class MainPage : ContentPage
{
    public ObservableCollection<User> Users { get; set; }
    public MainPage()
    {
        InitializeComponent();
        Users = new ObservableCollection<User>
        //Users = new List<User>
        {
            new User {Name="Tom", Age=38 },
            new User {Name = "Bob", Age = 42}
        };
        BindingContext = this; // привязка к текущему объекту
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        int.TryParse(ageEntry.Text, out var age);
        Users.Add(new User { Name = nameEntry.Text, Age = age });
        using (StreamWriter writer = new StreamWriter(@"D:\C#\glava8\glava8\test.txt", false))
        {
            writer.WriteLineAsync(Users[Users.Count() - 1].Name + " " + Users[Users.Count() - 1].Age);
        }   
        nameEntry.Text = ageEntry.Text = "";
    }
}

