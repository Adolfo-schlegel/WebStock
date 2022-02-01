using Microsoft.AspNetCore.Mvc;

namespace WebCalculadora.Controllers
{
    public class LoginController : Controller
    {
        [BindProperty]
        public Models.UserLogin ModelUser { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        
        public ActionResult LoginUser()
        {

            Models.UserLogin user = this.ModelUser;

            //validar usuario

            return Json(user.Email1, user.Password1);
        }

    }
}
