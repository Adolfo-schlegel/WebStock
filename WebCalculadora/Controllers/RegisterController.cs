using Microsoft.AspNetCore.Mvc;

namespace WebCalculadora.Controllers
{
    public class RegisterController : Controller
    {
        DataBase.RegisterBD Register = new DataBase.RegisterBD();

        [BindProperty]
        public Models.UserRegister UserRegister { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {       
            if(ModelState.IsValid)
            {
                //si es valido, haceme el registro
                Register.PostUser(UserRegister);

                //y mandame el stock de ese usuario || a iniciar sesion 
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }      
        }
    }
}
