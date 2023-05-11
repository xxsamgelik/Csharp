using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using System.Windows.Threading;

namespace lab25
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public static int Counter = 0;
        public static string[] questions =
        { "Ну что, давайте вспоминать героев фильма — семью Маккалистер. Честно говоря, желание Кевина избавиться от родственников можно понять, их уж ОЧЕНЬ много. Не будем мучить вас просьбой перечислить имена его родных, давайте попробуем посчитать, сколько детей было в доме в начале фильма?",
        "Ладно, это был сложный вопрос. Давайте попроще: в пригороде какого города находится дом Маккалистеров?",
        "А куда большое семейство собирается лететь на отдых?",
        "Возвращаемся к хардкорным вопросам. В самом начале фильма курьер приносит Маккалистерам 10 коробок пиццы. Именно из-за нее Кевин в итоге и ссорится со всей семьей. А сколько стоил заказ?",
        "Поговорим о Баззе — не очень приятном старшем брате Кевина. Помните, какое домашнее животное у него было (забыть такое сложно)?",
        "Еще один родственник Кевина — младший двоюродный брат Фуллер. Как зовут актера, сыгравшего эту роль?",
        "Кевина наказывают и отправляют спать на чердак. Завтра утром вылет в Париж. Но что-то идет не так, и вся семья встает позже запланированного. Что же случилось?"};

        public static string[] notes = { "Если вам это поможет, то из взрослых в доме только родители Кевина Питер и Кейт, а также дядя Фрэнк с тетей Лесли",
        "Думай лучше","Думай лучше","Хм, какой-то подозрительный полицейский… 🤔","Старший брат","Двоюродный брат Фуллер","Позже запланированого"};

        public static string[,] ans = { { "Восемь детей", "Девять детей", "Десять детей", "Одиннадцать детей" },
        { "Нью-Йорк", "Чикаго", "Миннеаполис", "Минск" },{"В Майами","На Гавайи","В париж","В Лондон"},
        {"87 долларов 50 центов","Ровно 100 долларов","122 доллара 50 центов","135 долларов" },
        {"Игуана","Скорпион","Тарантул","Всего-навсего попугай" },
        {"Тоби Магуайр","Это был Киран Калкин, брат Маколея Калкина","Нет, это был другой брат Маколея — Рори Калкин","Влад Лукашонок" },
        {"Маккалистерам не дают уснуть шумные соседи","Дерево падает на провода — электричество выключается — будильник не срабатывает","Взрослые слишком бурно отмечают, и никто не может их разбудить","Им не спалось" } };

        public static string[] end = { "Кевин вас ничему научил", "Кевин все таки вас чему-то научил, кевин", "Кевин вас хвалит, вы отлично знаете Один Дома" };

        public static string[] rightAns = { "Одинадцать детей", "Чикаго", "В париж", "122 доллара 50 центов", "Тарантул", "Это был Киран Калкин, брат Маколея Калкинаx", "Дерево падает на провода — электричество выключается — будильник не срабатывает" };
        public static List<string> myAns = new List<String>();
        public Test()
        {
            InitializeComponent();
            a.Content = ans[Counter, 0];
            b.Content = ans[Counter, 1];
            c.Content = ans[Counter, 2];
            d.Content = ans[Counter, 3];
            qst.Text = questions[Counter];
            count.Content = Convert.ToString(Counter) + "/6";
            help.Content = notes[Counter];
            System.Uri uri = new Uri($"d:\\c#\\lab25\\lab25\\video{Counter}.mp4");
            mediaPlayer.Source = uri;
        }
        public void Next_a(object sender, RoutedEventArgs e)
        {
            myAns.Add(ans[Counter, 0]);
            NextQST();
        }
        public void Next_b(object sender, RoutedEventArgs e)
        {
            myAns.Add(ans[Counter, 1]);
            NextQST();
        }
        public void Next_c(object sender, RoutedEventArgs e)
        {
            myAns.Add(ans[Counter, 2]);
            NextQST();
        }
        public void Next_d(object sender, RoutedEventArgs e)
        {
            myAns.Add(ans[Counter, 3]);
            NextQST();
        }
        public void NextQST()
        {
            try
            {
                if (Counter != 6)
                {
                    Counter++;
                    a.Content = ans[Counter, 0];
                    b.Content = ans[Counter, 1];
                    c.Content = ans[Counter, 2];
                    d.Content = ans[Counter, 3];
                    qst.Text = questions[Counter];
                    count.Content = Convert.ToString(Counter) + "/6";
                    help.Content = notes[Counter];
                    System.Uri uri = new Uri($"d:\\c#\\lab25\\lab25\\video{Counter}.mp4");
                    mediaPlayer.Source = uri;
                }
                else
                {
                    a.Content = "Завершить";
                    b.Visibility = Visibility.Hidden;
                    c.Visibility = Visibility.Hidden;
                    d.Visibility = Visibility.Hidden;
                    count.Visibility = Visibility.Hidden;
                    help.Content = "Спасибо за прохождение теста";
                    var ans = CountAns();
                    if (CountAns() < 2)
                    {
                        qst.Text = end[0];
                    }
                    else if (CountAns() >= 4)
                    {
                        qst.Text = end[1];
                    }
                    else
                    {
                        qst.Text = end[2];
                    }
                    FileWriteAns();

                }
            }
            catch
            {
                Close();
            }
            

        }
        public int CountAns()
        {
            int count = 0;
            for (int i = 0; i < rightAns.Length; i++)
            {
                if (myAns[i] == rightAns[i])
                {
                    count++;
                }
            }
            return count;
        }
        public void FileWriteAns()
        {
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                for (int i = 0; i < myAns.Count; i++)
                {
                    writer.WriteLine(questions[i] + " - " + myAns[i]);
                }
            }
        }
    }
}
