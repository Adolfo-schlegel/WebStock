using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;
using WebCalculadora.Services;
using WebCalculadora.Tools;

namespace WebCalculadora.Controllers.User
{
    public class CreateStockController : Controller
    {
        [BindProperty]
        public PlanillaCabecera? cabecera { get; set;}
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult N_inputs()
        {
            ViewData["count"] = cabecera.Count;

            return View("Index");
        }
        public async Task<ActionResult> N_inputsValues()
        {
            DecodedToken decoded = new DecodedToken();

            cabecera.User_id = decoded.Decoded(Request.Cookies["Token"]);

            PlanillaCabeceraBD service = new PlanillaCabeceraBD();

            int result = await service.POSTAsync(cabecera);

            if(result == 1)
            {
                return RedirectToAction("Index", "Planillas");
            }            
            return Json(cabecera.Campos_Json);
        }
    }    
}
