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

namespace PP_WPF
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        public int a;
        public int b;
        public int c;
        public bool isLength;
        public bool isSquare;

        public Input()
        {
            a = 0; b = 0; c = 0; isLength = false; isSquare = false;
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isSquare = true;

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            isLength= true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (text1.Text == ""||text2.Text == ""||text3.Text == "") MessageBox.Show("Пожалуйста, введите три значения");
            else
            {
                a = Int32.Parse(text1.Text);
                b = Int32.Parse(text2.Text);
                c = Int32.Parse(text3.Text);
                MessageBox.Show("Все хорошо!");
            }
        }
    }
}
