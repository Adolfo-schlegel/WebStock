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
            string respuesta = Register.PostUser(UserRegister.Email1, UserRegister.Password1, UserRegister.Password21);
            return null;
        }
    }
}
