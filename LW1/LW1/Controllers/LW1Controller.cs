using Microsoft.AspNetCore.Mvc;

namespace LW1.Controllers
{
    public class LW1Controller : Controller
    {
        public List<string> GetVegetablesList()
        {
            List<string> vegetabels = new List<string>();
            vegetabels.Add("Томат");
            vegetabels.Add("Огурец");
            vegetabels.Add("К");
            vegetabels.Add("Огурец");
            vegetabels.Add("Огурец");
            vegetabels.Add("Огурец");
            vegetabels.Add("Огурец");

        }
    }
}
