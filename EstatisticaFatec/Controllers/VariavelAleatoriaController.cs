using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.VariavelDiscreta;
using EstatisticaFatec.Core.VariavelDiscreta;

namespace EstatisticaFatec.Controllers
{
    public class VariavelAleatoriaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new VariavelDiscretaContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(InputEntity inputEntity)
        {
            var inputRequest = InputCore.Tratar(inputEntity);
            if (inputRequest.IsError)
            {
                ModelState.AddModelError("error", inputRequest.Message);
                return View(new VariavelDiscretaContainerEntity());
            }

            return View(new VariavelDiscretaApp().Build(inputRequest.Content));
        }
    }
}