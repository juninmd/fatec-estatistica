using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Models.VariavelQuantitativa;

namespace EstatisticaFatec.Controllers
{
    public class VariavelQuantitativaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new VariavelQuantitativaContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {

            var lista = massaDados.Split(',').Select(int.Parse).ToList();

            return View(new VariavelQuantitativaApp().Build(lista));
        }
    }
}