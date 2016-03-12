using EstatisticaFatec.Core;
using System.Web.Mvc;
using EstatisticaFatec.Core.Models.AleatoriaSimples;

namespace EstatisticaFatec.Controllers
{
    public class AleatoriaSimplesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new AleatoriaSimplesEntity());
        }

        [HttpPost]
        public ActionResult Index(int amostra, int populacao)
        {
            var request = new AleatoriaSimplesApp().ValidateInput(amostra, populacao);
            if (request.IsError)
            {
                ModelState.AddModelError("error", request.Message);
                return View(new AleatoriaSimplesEntity());
            }

            return View(new AleatoriaSimplesApp().Build(populacao, amostra));
        }
    }
}