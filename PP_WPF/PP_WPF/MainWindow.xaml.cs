using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PP_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Input input;
        Work work;
        public MainWindow()
        {
            InitializeComponent();
            this.input = new Input();
            this.work = new Work();
            work.Hide();
            input.Hide();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            input.Show();
        }

        private void Work_Click(object sender, RoutedEventArgs e)
        {
            this.work = new Work(input.a,input.b,input.c,input.isLength,input.isSquare);
            work.Show();
        }
 
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            input.Close();
            work.Close();
            this.Close();
        }
    }
}
