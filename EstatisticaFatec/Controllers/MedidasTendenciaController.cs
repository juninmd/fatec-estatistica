using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.MedidasTendencia;

namespace EstatisticaFatec.Controllers
{
    public class MedidasTendenciaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MedidasTendenciaContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(InputEntity inputEntity)
        {
            var inputRequest = InputCore.Tratar(inputEntity);
            if (inputRequest.IsError)
            {
                ModelState.AddModelError("error", inputRequest.Message);
                return View(new MedidasTendenciaContainerEntity());
            }

            return View(new MedidasTendenciaApp().Build(inputRequest.Content));
        }
    }
}