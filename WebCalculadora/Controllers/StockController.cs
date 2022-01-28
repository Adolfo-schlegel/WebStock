using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;

namespace WebCalculadora.Controllers
{
    public class StockController : Controller
    {
        DataBase.StockBD stockbd = new DataBase.StockBD();
        public async Task< IActionResult> Index()
        {
            /*
            //ejemplos de Envio de Datos
            ViewBag.Nombre = "Este es el ViewBag";
            ViewData["Apellido"] = "Este es el ViewData";
            TempData["Usuario"] = "Este es el TempData";
            //ejemplo de como enviar una lista 

            System.Diagnostics.Debug.WriteLine(model.Marca);
            */

            DataBase.StockBD stock = new ();//creo ob de operaciones bd

            //este elemento view data se conecta con el modelo de mi modelo objeto insertado en html, al que le asigno todos mis registros de la bd 
            ViewData["Stock"] = await stock.Read();
          
            return View();
        }

        [BindProperty]
        public Stock Stock { get; set; }
        public ActionResult setStock()
        {

            stockbd.Set<Stock>(Stock, "POST");

            return RedirectToAction("Index");
        }
        
        public IActionResult Eliminar(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            

            return View();
        }

        public IActionResult Modificar(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            

            return View();
        }
    }
}
