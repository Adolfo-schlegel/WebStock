using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;

namespace WebCalculadora.Controllers
{
    public class StockController : Controller
    {
        [BindProperty]
        public Stock ModelStock { get; set; }

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
        public ActionResult GuardarRegistro()
        {          
            stockbd.Set<Stock>(ModelStock, "POST");

            return RedirectToAction("Index");
        }    
        public IActionResult EliminarRegistro(int id)
        {
            bool result = stockbd.Delete(id, "DELETE");

            if(result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task <IActionResult> ModificarRegistro(int id)
        {
            Models.Stock stock = stockbd.Read_id(id)[0];//busco el registro con el id 

            return View(stock);
        }      
        public ActionResult SetModificacion()
        {
            stockbd.Put(ModelStock, "PUT");

            return RedirectToAction("Index");
        }
    }
}
 