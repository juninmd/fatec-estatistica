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
            return View(new MedidasDispersaoContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {
            var inputRequest = InputCore.Tratar(massaDados);
            if (inputRequest.IsError)
            {
                ModelState.AddModelError("error", inputRequest.Message);
                return View(new MedidasDispersaoContainerEntity());
            }

            return View(new MedidasDispersaoApp().Build(inputRequest.Content));
        }
    }
}