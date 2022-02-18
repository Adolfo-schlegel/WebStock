using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;

namespace WebCalculadora.Controllers
{
    public class StockController : Controller
    {
        [BindProperty]
        public Stock? ModelStock { get; set; }

        DataBase.StockBD stockbd = new DataBase.StockBD();
        public async Task<IActionResult> Index()
        {
            ViewData["Stock"] = await stockbd.Read();

            return View();
        }

        public async Task<ActionResult> GuardarRegistro()
        {
            string result = await stockbd.Set(ModelStock);

            return RedirectToAction("Index");
        }
        public async Task<ActionResult> EliminarRegistro(int id)
        {
            string result = await stockbd.Delete(id, "DELETE");

            if (result == "true")
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult ModificarRegistro(int id)
        {
            Models.Stock stock = stockbd.Read_id(id).Result;//busco el registro con el id 

            return View(stock);
        }
        public async Task<ActionResult> SetModificacion()
        {
            string result = await stockbd.Put(ModelStock);

            return RedirectToAction("Index");
        }
    }
}
