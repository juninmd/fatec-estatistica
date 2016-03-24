using EstatisticaFatec.Core;
using System.Web.Mvc;
using EstatisticaFatec.Core.Models.Sistematica;

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
            var request = new AleatoriaSimplesApp().ValidateInput(amostra, populacao);
            if (request.IsError)
            {
                ModelState.AddModelError("error", request.Message);
                return View(new SistematicaEntity());
            }

            return View(new SistematicaApp().Build(amostra, inicial, populacao));
        }
    }
}