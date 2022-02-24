using Microsoft.AspNetCore.Mvc;
using WebCalculadora.Services;
using WebCalculadora.Models;
namespace WebCalculadora.Controllers.User
{
    public class MenuController : Controller
    {
        Models.User user = new Models.User();

        UserStockBD UserStockService = new UserStockBD();

        [BindProperty]
        public UserStock UserStock { get; set; }
     
        public IActionResult Index()
        {
            if (Request.Cookies["Token"] != null)                           
                return View();            
            return RedirectToAction("Index", "Login");
        }
        
        public async Task<ActionResult> MenuStock()
        {
            if (Request.Cookies["Token"] != null)
            {
                user.User_id = Get_idSesionUser();

                ViewData["StockUser"] = await UserStockService.Get_stock(user);//consulta a servico sobre stock

                return View(UserStock);
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult CreateStock()
        {            
            return View();
        }

        public async Task<ActionResult> GuardarRegistro()
        {
            if (ModelState.IsValid)
            {
                Reply oR = new Reply();
                UserStock.User_id = Get_idSesionUser();
                oR = await UserStockService.SetStockAsync(UserStock);
            }

            return RedirectToAction("MenuStock");
        }

        public async Task<ActionResult> EliminarRegistro(int id)
        {
            Reply oR = new Reply();

            oR = await UserStockService.Delete(id);

            if(oR.result != 0)
            {
                return RedirectToAction("MenuStock");
            }
           
            return View();
        }
        public async Task<ActionResult> ModificarStock(int id)
        {
            UserStock = await UserStockService.ReadIdAsync(id);
            return View(UserStock);
        }
        public async Task<ActionResult> SetModificacion()
        {
            Reply oR = new Reply();

            oR = await UserStockService.ModifyStock(UserStock);

            return RedirectToAction("MenuStock");
        }

        public ActionResult Logout()
        {            
            if(Request.Cookies["Token"] != null)
            {
                Response.Cookies.Delete("Token");

                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");
        }
        public int Get_idSesionUser()
        {
            var token = Request.Cookies["Token"];//guardo cookies

            Models.User user = new Models.User();//creo modelo donde se almacenara mi id

            Tools.DecodedToken decoded = new Tools.DecodedToken();//decodificador de tokens

            return (int)(user.User_id = decoded.Decoded(token.ToString()));
        }
    }
}
