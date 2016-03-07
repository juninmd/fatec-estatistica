using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Controllers
{
    public class VariavelDiscretaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new VariavelDiscretaContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {

            var lista = massaDados.Split(',').Select(int.Parse).ToList();

            return View(new VariavelDiscretaApp().Build(lista));
        }
    }
}