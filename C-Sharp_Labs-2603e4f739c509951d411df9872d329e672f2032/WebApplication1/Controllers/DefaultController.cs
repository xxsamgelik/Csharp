using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult FirstViewMethod()
        {
            List<string> list = GetVegetablesList();
            SecondViewMethod();
            return View(list);
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
            List<string> vegetables = new List<string>
            {
                "Томат",
                "Огурец",
                "Картофель",
                "Кабачок",
                "Баклажан",
                "Капуста",
                "Брокколи"
            };
            return vegetables;
        }
    }
}