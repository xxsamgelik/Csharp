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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace PP_WPF
{
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>
    public partial class Work : Window
    {
        public int a;
        public int b;
        public int c;
        public bool isLength;
        public bool isSquare;
        public Work()
        {
            InitializeComponent();
        }
        public double GetLenght()
        {
            return Math.PI * a * 2;
        }
        public double GetSquare()
        {
            double I = Math.Sqrt(a * a + b * b);
            double Sbok = Math.PI*a*I;
            return Sbok + GetLenght();
        }
        public Work(int a, int b, int c, bool isLength, bool isSquare)
        {
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.c = c;
            this.isLength = isLength;
            this.isSquare = isSquare;
            if (this.isLength)
            {
                double len = GetLenght();
                textLenght.Content = "Lengt: " + Math.Round(len,2);
            }
            if (this.isSquare)
            {
                textSquare.Content = "Square: " + Math.Round(GetSquare(),2);
            }
            else
            {
                textLenght.Content = "Length:";
                textSquare.Content = "Square :";

            }
        }
    }
}
