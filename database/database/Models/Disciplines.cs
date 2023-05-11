using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Models
{
    public class Disciplines
    {
        public int id { get; set; }
        public string Дисциплина { get; set; }
        public string Учитель { get; set; }
        public int КоличествоCтудентов { get; set; }
        public int ЧасыЛекций { get; set; }
        public int ЧасыПрактики { get; set; }
        public bool КурсоваяРабота { get; set; }

        public override string ToString()
        {
            return $"Name: {Дисциплина} Учитель: {Учитель} Количество студентов: {КоличествоCтудентов}" +
                $" Часы лекций: {ЧасыЛекций} Часы практики: {ЧасыПрактики} Курсовая работа: {КурсоваяРабота}";
        }

    }
}
