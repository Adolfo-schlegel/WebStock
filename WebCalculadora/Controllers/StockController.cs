using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;

namespace WebCalculadora.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            //ejemplos de Envio de Datos
            ViewBag.Nombre = "Este es el ViewBag";
            ViewData["Apellido"] = "Este es el ViewData";
            TempData["Usuario"] = "Este es el TempData";
            //ejemplo de como enviar una lista 

            DataBase.StockBD stock = new ();      
            
            ViewData["Stock"] = stock.Read();

            return View();
        }

     
        public Models.Stock Stock { get => Stock; set => Stock = value; }

        public ActionResult setStock()
        {
            return Json(Stock);
        }
        
    }
}
