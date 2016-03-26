using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.VariavelDiscreta;

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
            var inputRequest = InputCore.Tratar(massaDados);
            if (inputRequest.IsError)
            {
                ModelState.AddModelError("error", inputRequest.Message);
                return View(new VariavelDiscretaContainerEntity());
            }

            return View(new VariavelDiscretaApp().Build(inputRequest.Content));
        }
    }
}