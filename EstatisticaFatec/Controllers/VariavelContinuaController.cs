using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.VariavelContinua;

namespace EstatisticaFatec.Controllers
{
    public class VariavelContinuaController : Controller
    {
        // GET: VariavelQuantitativa
        public ActionResult Index()
        {
            return View(new VariavelContinuaContainerEntity());
        }
        [HttpPost]
        public ActionResult Index(InputEntity inputEntity)
        {
            var inputRequest = InputCore.Tratar(inputEntity);
            if (inputRequest.IsError)
            {
                ModelState.AddModelError("error", inputRequest.Message);
                return View(new VariavelContinuaContainerEntity());
            }

            return View(new VariavelContinuaApp().Build(inputRequest.Content));
        }
    }
}