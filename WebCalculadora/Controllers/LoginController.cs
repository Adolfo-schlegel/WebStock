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

        
        public async Task<ActionResult> LoginUser()
        {
            if(ModelState.IsValid)
            {
                DataBase.LoginBD loginBD = new DataBase.LoginBD();
                int result = await loginBD.ValidateUserAsync(ModelUser);

                if(result >0)
                {
                    //hacer un select al stock del cliente y buscar sus registros por id del usuario 
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
