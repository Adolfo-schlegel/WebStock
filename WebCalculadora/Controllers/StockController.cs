using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;

namespace WebCalculadora.Controllers
{
    public class StockController : Controller
    {
        DataBase.StockBD stockbd = new DataBase.StockBD();
        public async Task< IActionResult> Index()
        {
            //ejemplos de Envio de Datos
            ViewBag.Nombre = "Este es el ViewBag";
            ViewData["Apellido"] = "Este es el ViewData";
            TempData["Usuario"] = "Este es el TempData";
            //ejemplo de como enviar una lista 

            DataBase.StockBD stock = new ();

            //este elemento view data se conecta con el modelo de mi modelo objeto insertado en html, al que le asigno todos mis registros de la bd 
            ViewData["Stock"] = await stock.Read();

            return View();
        }

        [BindProperty]
        public Stock Stock { get; set; }
        public ActionResult setStock()
        {
            string url = "http://lanota.3utilities.com/api/values";

            stockbd.Set<Stock>(url, Stock, "POST");

            return RedirectToAction("Index");
        }
        
    }
}
