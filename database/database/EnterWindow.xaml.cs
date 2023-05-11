using database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        Disciplines disciplines;
        public EnterWindow()
        {
            InitializeComponent();
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(nameTeacherTextBox.Text)
                    || string.IsNullOrEmpty(counterTextBox.Text) || string.IsNullOrEmpty(hoursLectionTextBox.Text)
                    || string.IsNullOrEmpty(hooursPracticTextBox.Text) || string.IsNullOrEmpty(courseTextBox.Text))
                {
                    throw new Exception("Не все поля заполнены");
                }

                if (!char.IsUpper(nameTextBox.Text[0]) || !char.IsUpper(nameTeacherTextBox.Text[0]))
                {
                    throw new Exception("Название дисциплины или имя преподователя должны начинаться с большой буквы");
                }

                var practic = int.Parse(hooursPracticTextBox.Text);
                var lection = int.Parse(hoursLectionTextBox.Text);
                if ( practic> 0 && lection > 0) { throw new Exception("Количество часов практики и лекций должно быть положительным"); }


                disciplines = new Disciplines()
                {
                    Дисциплина = nameTextBox.Text,
                    Учитель = nameTeacherTextBox.Text,
                    КоличествоCтудентов = int.Parse(counterTextBox.Text),
                    ЧасыЛекций = lection,
                    ЧасыПрактики = practic,
                    КурсоваяРабота = bool.Parse(courseTextBox.Text)
                };

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public new Disciplines ShowDialog()
        {
            base.ShowDialog();

            return disciplines;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
