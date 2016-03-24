using EstatisticaFatec.Core;
using System.Web.Mvc;
using EstatisticaFatec.Core.Models.EstratificadaUniforme;

namespace EstatisticaFatec.Controllers
{
    public class EstratificadaUniformeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new EstratificadaUniformeEntity());
        }

        [HttpPost]
        public ActionResult Index(int amostra, int estrato)
        {
            var request = new EstratificadaUniformeApp().ValidateInput(amostra, estrato);
            if (request.IsError)
            {
                ModelState.AddModelError("error", request.Message);
                return View(new EstratificadaUniformeEntity());
            }
            return View(new EstratificadaUniformeApp().Build(amostra, estrato));
        }
    }
}