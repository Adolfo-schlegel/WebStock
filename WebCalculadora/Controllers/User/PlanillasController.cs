using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCalculadora.Models;
using WebCalculadora.Services;
using WebCalculadora.Tools;

namespace WebCalculadora.Controllers.User
{
    public class PlanillasController : Controller
    {
        [BindProperty]
        public static PlanillaCabecera? PlanillaCabecera  { get; set; }
        private DecodedToken decode = new DecodedToken();
        private PlanillaCabeceraBD service = new PlanillaCabeceraBD();

        public PlanillasController()
        {
            PlanillaCabecera = new PlanillaCabecera();
        }

        public async Task<IActionResult> Index()
        {            
            PlanillaCabecera.LstDeNombres = await GetNamesColumns();

            // planillaCabecera.LstDeNombres = items;

            return View(PlanillaCabecera);
        }
        public async Task<ActionResult> ChangeTable()
        {
            var selectedid = Request.Form["Datos"].ToString();

            PlanillaCabecera.Campos_Json = await service.GetColumnsByNameTable(decode.Decoded(Request.Cookies["Token"]), selectedid);
            PlanillaCabecera.LstDeNombres = await GetNamesColumns();
            //ViewBag.TableColumns = await service.GetColumnsByNameTable(decode.Decoded(Request.Cookies["Token"]), selectedid);

            return View("Index",PlanillaCabecera);
        }

        public async Task<List<SelectListItem>> GetNamesColumns()
        {
            List<string> lst = await service.GET_NamesAsync(decode.Decoded(Request.Cookies["Token"]));

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.ToString(),
                    Value = d.ToString(),
                    Selected = false
                };
            });

            return items;
        }
    }
}
