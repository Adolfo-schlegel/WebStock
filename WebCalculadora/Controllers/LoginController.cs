using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Models;
using WebCalculadora.Services;
namespace WebCalculadora.Controllers
{
    public class LoginController : Controller
    {        
        [BindProperty]
        public Models.UserLogin ModelUser { get; set; }
        public IActionResult Index()
        {
            if (Request.Cookies["Token"] != null)
            {
                return RedirectToAction("Index", "Menu");
            }

            return View();
        }  
        public async Task<ActionResult> LoginUser()
        {
            Reply? oR = new Reply();

            if (ModelState.IsValid)
            {
                Auth auth = new Auth(); 
                oR = await auth.AuthUser(ModelUser); //verify password and generate token 

                if(oR.result > 0)
                {
                    SetCookie(oR.data.ToString());                                        

                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    if(oR.message == "")
                         ModelState.AddModelError("Email1","El correo o la contraseña son incorrectos");
                    else
                         ModelState.AddModelError("Email1", oR.message);
                    return View("Index");
                }                
            }
            return Json(oR.message);
        }

        private void SetCookie(string token)
        {
            CookieOptions Options = new CookieOptions();
            Options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("Token", token, Options);
        }

        //private string GetCookie()
        //{
        //    string? resultCookie = Request.Cookies["Token"];

        //    return resultCookie;
        //}

    }
}
