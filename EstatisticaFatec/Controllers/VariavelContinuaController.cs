using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core;
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
        public ActionResult Index(string massaDados)
        {
            var inputRequest = InputCore.Tratar(massaDados);
            if (inputRequest.IsError)
            {
                ModelState.AddModelError("error", inputRequest.Message);
                return View(new VariavelContinuaContainerEntity());
            }

            return View(new VariavelContinuaApp().Build(inputRequest.Content));
        }
    }
}