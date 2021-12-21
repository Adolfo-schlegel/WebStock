using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebCalculadora.Controllers
{
    
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult info()
        {
            //tipos de envios de datos 
            

            return View();
        }


      
    }
}
