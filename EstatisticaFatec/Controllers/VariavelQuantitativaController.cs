using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Models;

namespace EstatisticaFatec.Controllers
{
    public class VariavelQuantitativaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new EntidadeContainer());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {

            var lista = massaDados.Split(',').Select(int.Parse).ToList();

            return View(new VariavelQuantitativaApp().Build(lista));
        }
    }
}