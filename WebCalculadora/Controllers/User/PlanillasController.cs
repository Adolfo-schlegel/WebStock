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
        public static PlanillaCabecera? PlanillaCabecera { get; set; }
        private DecodedToken decode = new DecodedToken();
        private PlanillaCabeceraBD serviceCabecera = new PlanillaCabeceraBD();
        private PlanillaRegistroBD serviceRegistro = new PlanillaRegistroBD();

        public PlanillasController()
        {
            PlanillaCabecera = new PlanillaCabecera();
        }

        public async Task<IActionResult> Index()
        {
            PlanillaCabecera.LstDeNombres = await GetNamesColumns();

            return View(PlanillaCabecera);
        }
        public async Task<ActionResult> ChangeTable()
        {
            var selectedid = Request.Form["Datos"].ToString();
            var cabecera = await serviceCabecera.GetColumnsByNameTable(decode.Decoded(Request.Cookies["Token"]), selectedid);

            PlanillaCabecera.Campos_Json = cabecera.Campos_Json;
            PlanillaCabecera.LstDeNombres = await GetNamesColumns();
            ViewBag.ListaRegistros = await GetListStock(cabecera.Id);            

            return View("Index", PlanillaCabecera);
        }

        public async Task<List<SelectListItem>> GetNamesColumns()
        {
            List<string> lst = await serviceCabecera.GET_NamesAsync(decode.Decoded(Request.Cookies["Token"]));

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

        public async Task<List<List<string>>> GetListStock(int cabecera_id)
        {
            List<PlanillaRegistros>? lst = await serviceRegistro.GetStockAsync(cabecera_id);

            List<List<string>>? lstRegistros = lst.Select(d => d.Registros_Json).ToList();

            return lstRegistros;
        }

    }
}
