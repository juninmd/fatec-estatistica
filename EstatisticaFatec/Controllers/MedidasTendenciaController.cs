using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.MedidasTendencia;

namespace EstatisticaFatec.Controllers
{
    public class MedidasTendenciaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MedidasTendenciaEntity());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {
            var lista = massaDados.Split(';').Select(decimal.Parse).ToList();

            return View(new MedidasTendenciaApp().Build(lista));
        }
    }
}