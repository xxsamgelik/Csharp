using database.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System;

namespace database
{
    /// <summary>
    /// Логика взаи одействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : System.Windows.Window
    {
        MobileContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new MobileContext();
            db.Disciplines.Load();
            phonesGrid.ItemsSource = db.Disciplines.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    Disciplines phone = phonesGrid.SelectedItems[i] as Disciplines;
                    if (phone != null)
                    {
                        db.Disciplines.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EnterWindow enterWindow = new EnterWindow
            {
                Owner = this
            };
            var disciplines = enterWindow.ShowDialog();
            if (enterWindow.DialogResult == true)
            {
                db.Disciplines.Add(disciplines);
                db.SaveChanges();
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Disciplines.OrderBy(s => s.Дисциплина).ThenBy(s => s.Учитель);
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            ExportTable(ref document, query.ToList());
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\SortedDataBase.docx");
            var str = "";
            foreach (var disciplines in query)
            {
                str += $"{disciplines.id} \t{disciplines.Дисциплина} \t{disciplines.Учитель}" + "\n";
            }
            MessageBox.Show(str);
        }

        private void ShowDev_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Disciplines.Where(s => s.КурсоваяРабота).Select(s => s.Дисциплина);

            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            ExportTitle(ref document, query.ToList());
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\Sort2DataBase.docx");

            var str = "";
            foreach (var disciplines in query)
            {
                str += $"{disciplines}" + "\n";
            }
            MessageBox.Show(str);
        }

        private void MostExam_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Disciplines.OrderByDescending(t => t.КоличествоCтудентов).FirstOrDefault();
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            ExportText(ref document, query);
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\Sort3DataBase.docx");
            var str = "";
            str += $"{query}" + "\n";
            MessageBox.Show(str);
        }
        private void AllPractic_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Disciplines.Sum(d => d.ЧасыПрактики);
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            ExportText(ref document, query);
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\Sort3DataBase.docx");

            var str = "";
            str += $"{query}" + "\n";
            MessageBox.Show(str);
        }
        private void Group_Click(object sender, RoutedEventArgs e)
        {
            var disciplineByName = db.Disciplines.GroupBy(discipline => discipline.Дисциплина);
            ShowGroup(disciplineByName, "названием");

            var disciplineByTeacher = db.Disciplines.GroupBy(discipline => discipline.Учитель);
            ShowGroup(disciplineByTeacher, "учителем");

            var countStudents = db.Disciplines.GroupBy(discipline => discipline.КоличествоCтудентов);
            ShowGroupInt(countStudents, "количеством студентов");

            var hoursLections = db.Disciplines.GroupBy(discipline => discipline.ЧасыЛекций);
            ShowGroupInt(hoursLections, "количеством часов лекций");

            var hoursPractic = db.Disciplines.GroupBy(discipline => discipline.ЧасыПрактики);
            ShowGroupInt(hoursPractic, "количеством часов практики");

            var isCourseWork = db.Disciplines.GroupBy(discipline => discipline.КурсоваяРабота);
            ShowGroupBool(isCourseWork, "курсовой");
        }
        void ShowGroup(IEnumerable<IGrouping<string, Disciplines>> groupBy, string str)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            var message = "";
            foreach (var group in groupBy)
            {
                ExportText(ref document, String.Format("Дисципллины с " + str + " \"" + group.Key + "\":\n"));
                message += ("Дисципллины с " + str + " \"" + group.Key + "\":") + "\n";
                foreach (var disciplines in group)
                {
                    ExportText(ref document, String.Format(("- " + disciplines.Дисциплина) + "\n"));
                    message += ("- " + disciplines.Дисциплина) + "\n";
                }
            }
            MessageBox.Show(message);
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\" + str + ".docx");
        }
        void ShowGroupInt(IEnumerable<IGrouping<int, Disciplines>> groupBy, string str)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            var message = "";
            foreach (var group in groupBy)
            {
                ExportText(ref document, String.Format("Дисципллины с " + str + " \"" + group.Key + "\":\n"));
                message += ("Дисципллины с " + str + " \"" + group.Key + "\":") + "\n";
                foreach (var disciplines in group)
                {
                    ExportText(ref document, String.Format(("- " + disciplines.Дисциплина) + "\n"));
                    message += ("- " + disciplines.Дисциплина) + "\n";
                }
            }
            MessageBox.Show(message);
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\" + str + ".docx");
        }
        void ShowGroupBool(IEnumerable<IGrouping<bool, Disciplines>> groupBy, string str)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();
            var message = "";
            foreach (var group in groupBy)
            {
                ExportText(ref document, String.Format("Дисципллины с " + str + " \"" + group.Key + "\":\n"));
                message += ("Дисципллины с " + str + " \"" + group.Key + "\":") + "\n";
                foreach (var disciplines in group)
                {
                    ExportText(ref document, String.Format(("- " + disciplines.Дисциплина) + "\n"));
                    message += ("- " + disciplines.Дисциплина) + "\n";
                }
            }
            MessageBox.Show(message);
            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\" + str + ".docx");
        }
        private void ExportToWord_Click(object sender, RoutedEventArgs e)
        {
            var allGames = db.Disciplines.ToList();
            var application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Add();

            ExportTitle(ref document, allGames);

            ExportTable(ref document, allGames);

            application.Visible = true;
            document.SaveAs2(@"C:\Users\xxsam\OneDrive\Рабочий стол\DataBase.docx");
        }

        private void ExportTitle<T>(ref Document document, List<T> values)
        {
            foreach (var disciplines in values)
            {
                ExportText(ref document, disciplines);
            }
        }

        private void ExportText<T>(ref Document document, T value)
        {
            Microsoft.Office.Interop.Word.Paragraph gameParagrap = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range gameRange = gameParagrap.Range;
            gameRange.Text = value.ToString();
            gameParagrap.set_Style("Обычный");
            gameRange.InsertParagraphAfter();
        }

        private void ExportTable(ref Document document, List<Disciplines> disciplines)
        {
            Microsoft.Office.Interop.Word.Paragraph tableParagrap = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range tableRange = tableParagrap.Range;
            Microsoft.Office.Interop.Word.Table priceTable = document.Tables.Add(tableRange, disciplines.Count() + 1, 6);
            priceTable.Borders.InsideLineStyle = priceTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            priceTable.Range.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Microsoft.Office.Interop.Word.Range cellRange;

            cellRange = priceTable.Cell(1, 1).Range;
            cellRange.Text = "Название";
            cellRange = priceTable.Cell(1, 2).Range;
            cellRange.Text = "Учитель";
            cellRange = priceTable.Cell(1, 3).Range;
            cellRange.Text = "КоличествоСтудентов";
            cellRange = priceTable.Cell(1, 4).Range;
            cellRange.Text = "ЧасыЛекций";
            cellRange = priceTable.Cell(1, 5).Range;
            cellRange.Text = "ЧасыПрактики";
            cellRange = priceTable.Cell(1, 6).Range;
            cellRange.Text = "КурсоваяРабота";

            for (int i = 0; i < disciplines.Count(); ++i)
            {
                var currentDiscipline = disciplines[i];

                cellRange = priceTable.Cell(i + 2, 1).Range;
                cellRange.Text = currentDiscipline.Дисциплина;

                cellRange = priceTable.Cell(i + 2, 2).Range;
                cellRange.Text = currentDiscipline.Учитель;

                cellRange = priceTable.Cell(i + 2, 3).Range;
                cellRange.Text = currentDiscipline.КоличествоCтудентов.ToString();

                cellRange = priceTable.Cell(i + 2, 4).Range;
                cellRange.Text = currentDiscipline.ЧасыЛекций.ToString();

                cellRange = priceTable.Cell(i + 2, 5).Range;
                cellRange.Text = currentDiscipline.ЧасыПрактики.ToString();

                cellRange = priceTable.Cell(i + 2, 6).Range;
                cellRange.Text = currentDiscipline.КурсоваяРабота.ToString();
            }
        }





    }

}
