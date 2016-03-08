using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.VariavelContinua;

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

            var lista = massaDados.Split(';').Select(int.Parse).ToList();

            return View(new VariavelContinuaApp().Build(lista));
        }
    }
}