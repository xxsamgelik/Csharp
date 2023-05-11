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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            var win1 = new win1();
            win1.Show();
            win1.Title = btn1.Name;
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            var win1 = new win1();
            win1.Show();
            win1.Title = btn2.Name;
            this.Close();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            var win1 = new win1();
            win1.Show();
            win1.Title = btn3.Name;
            this.Close();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            var win1 = new win1();
            win1.Show();
            win1.Title = btn4.Name;
            this.Close();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            var win1 = new win1();
            win1.Show();
            win1.Title = btn5.Name;
            this.Close();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            var win1 = new win1();
            win1.Show();
            win1.Title = btn6.Name;
            this.Close();
        }
    }
}
