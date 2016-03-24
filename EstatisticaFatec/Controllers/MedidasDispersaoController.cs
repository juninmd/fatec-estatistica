using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.MedidasDispersao;

namespace EstatisticaFatec.Controllers
{
    public class MedidasDispersaoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MedidasDispersaoEntity());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {
            var lista = massaDados.Split(';').Select(decimal.Parse).ToList();

            return View(new MedidasDispersaoApp().Build(lista));
        }
    }
}