using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_26_PP.Controllers
{
    public class Lab26Controller : Controller
    {
        // GET: Lab26
        public ActionResult FirstViewMethod()
        {
            List<string> vegetables = GetVegetablesList();
            return View(vegetables);
        }

        public ActionResult SecondViewMethod()
        {
            return View(GetVegetablesList().OrderBy(x => x).ToList());
        }
        public ActionResult ThirdViewMethod()
        {
            return View(GetVegetablesList().OrderBy(x => x).ToList());
        }
        public List<string> GetVegetablesList()
        {
            List<string> vegetables = new List<string>();
            vegetables.Add("Томат");
            vegetables.Add("Огурец");
            vegetables.Add("Картофель");
            vegetables.Add("Кабачок");
            vegetables.Add("Баклажан");
            vegetables.Add("Капуста");
            vegetables.Add("Брокколи");
            vegetables.Add("Баклажан");

            return vegetables;
        }
        
    }
}