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
        
            return View(new EstratificadaUniformeApp().Build(amostra, estrato));
        }
    }
}