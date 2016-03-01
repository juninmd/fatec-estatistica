using EstatisticaFatec.Core;
using System.Web.Mvc;
using EstatisticaFatec.Models.EstratificadaUniforme;
using EstatisticaFatec.Models.Sistematica;

namespace EstatisticaFatec.Controllers
{
    public class SistematicaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SistematicaEntity());
        }

        [HttpPost]
        public ActionResult Index(int amostra, int inicial, int populacao)
        {
            return View(new SistematicaApp().Build(amostra, inicial, populacao));
        }
    }
}