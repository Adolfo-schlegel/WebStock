using System.Linq;
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

        //--inyectar
        private DecodedToken decode = new();
        private PlanillaCabeceraBD serviceCabecera = new ();
        private PlanillaRegistroBD serviceRegistro = new ();
        //--inyectar

        public PlanillasController()
        {
            PlanillaCabecera = new ();
        }
        public async Task<IActionResult> Index()
        {
            PlanillaCabecera.LstDeNombres = await GetNamesColumns();
            PlanillaCabecera.Nombre_tabla = "";
            return View(PlanillaCabecera);
        }
        public async Task<ActionResult> LoadPage()
        {            
            string selectedCabecera = "";
            string name = TempData["cabecera_id"]?.ToString();
            
            if (name != null && name != "")
            {
                selectedCabecera = await serviceCabecera.GetNamePlanillaById(int.Parse(TempData["cabecera_id"].ToString()));
            }
            else
            {
                selectedCabecera = Request.Form["Datos"].ToString();        //me toma el nombre seleccionado del id del ListOpcion
            }

            var cabecera = await serviceCabecera.GetColumnsByNameTable(decode.Decoded(Request.Cookies["Token"]), selectedCabecera);

            PlanillaCabecera.Campos_Json = cabecera.Campos_Json;            //columnas tabla
            PlanillaCabecera.LstDeNombres = await GetNamesColumns();        //combobox nombres
            ViewBag.ListaRegistros = await GetListItems(cabecera.Id);       //registros tabla
            PlanillaCabecera.Nombre_tabla = selectedCabecera.ToString();    //nombre de la tabla
            PlanillaCabecera.cabecera_id = cabecera.Id;                     //id tabla  
              
            return View("Index", PlanillaCabecera);
        }
        private async Task<List<SelectListItem>> GetNamesColumns()
        {
            List<string> lst = await serviceCabecera.GetTableNamesAsync(decode.Decoded(Request.Cookies["Token"]));

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
        private async Task<List<List<string>>> GetListItems(int cabecera_id)
        {
            List<PlanillaRegistros>? lstplanillas = await serviceRegistro.GetStockAsync(cabecera_id);

            List<List<string>>? lstRegistros = lstplanillas.Select(d => d.Registros_Json).ToList();

            for (int i = 0; i < lstRegistros.Count; i++)            
                lstRegistros[i].Add(lstplanillas[i].Id.ToString());
            
            return lstRegistros;
        }
        private async Task<List<string>> GetListItemById(int id)
        {
            return await serviceRegistro.GetStockItemAsync(id);
        }

        public async Task<ActionResult> DeleteStock(int id, int header_id)
        {
            int result = await serviceRegistro.DeleteStockByIdAsync(id);
            TempData["cabecera_id"] = header_id;
            return RedirectToAction("LoadPage", "Planillas");
        }
        [HttpGet]
        public async Task<ActionResult> EditItem(int? id, int header_id)
        {
            PlanillaCabecera.Registros_Json =  await serviceRegistro.GetStockItemAsync(id);
            TempData["cabecera_id"] = header_id;
            //PlanillaCabecera.cabecera_id = header_id;

            return View(PlanillaCabecera);
        }

        [HttpPost]
        public async Task<ActionResult> EditItem(PlanillaCabecera model)
        {
            int result = await serviceRegistro.ModifyStockAsync(model);
            
            if(result == 0)
            {
                return Json("Error 404");
            }

            return RedirectToAction("LoadPage", "Planillas");
        }

        public async Task<ActionResult> CreateStock(int header_id)
        {
            int result = await serviceRegistro.PostStockAsync(new PlanillaRegistros { Registros_Json = Request.Form["Registros_Json"].ToList(), cabecera_id = header_id });
           
            if (result != 0)
            {
                TempData["cabecera_id"] = header_id;
                return RedirectToAction("LoadPage", "Planillas");
            }
                 
            return Json("ERROR 404");
        }
    }
}
