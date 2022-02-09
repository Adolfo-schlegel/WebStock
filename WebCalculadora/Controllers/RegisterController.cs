using Microsoft.AspNetCore.Mvc;

namespace WebCalculadora.Controllers
{
    public class RegisterController : Controller
    {
        DataBase.RegisterBD Register = new DataBase.RegisterBD();

        [BindProperty]
        public Models.UserRegister? UserRegister { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public async  Task<ActionResult> RegisterUser()
        {       
            if(ModelState.IsValid)
            {
                //si es valido, haceme el registro
                int result = await Register.PostUser(UserRegister);

                if(result == 200)
                {
                    //
                    return RedirectToAction("Index");
                }
                else
                {
                    return Json("??");
                }                      
            }
            else
            {
                return RedirectToAction("Index");
            }      
        }
    }
}
