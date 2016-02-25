using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Models;
using EstatisticaFatec.Models.VariavelContinua;
using EstatisticaFatec.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Controllers
{
    public class VariavelContinuaController : Controller
    {
        // GET: VariavelQuantitativa
        public ActionResult Index()
        {
            return View(new VariavelContinuaContainerEntity());
        }
        [HttpPost]
        public ActionResult Index(string massaDados)
        {

            var lista = massaDados.Split(',').Select(int.Parse).ToList();

            return View(new VariavelContinuaApp().Build(lista));
        }
    }
}