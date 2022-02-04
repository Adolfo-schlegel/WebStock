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
            if(ModelState.IsValid)
            {
                DataBase.LoginBD loginBD = new DataBase.LoginBD();
                bool result = loginBD.ValidateUser(ModelUser);

                if(result == true)
                {
                    return RedirectToAction("LoginOK");
                }
                else
                {
                    return Json("Usuario no registrado");
                }
                
            }

            return Json("error");
        }

        public ActionResult LoginOK()
        {
            return Json("valido");
        }

    }
}
