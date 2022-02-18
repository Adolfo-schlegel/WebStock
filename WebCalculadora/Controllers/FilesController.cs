using Microsoft.AspNetCore.Mvc;

namespace WebCalculadora.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult Download()
        {
            return View();
        }
        public ActionResult DeleteFile()
        {
            return View();
        }
        public ActionResult CreateFolder()
        {
            return View();
        }
    }
}
