using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;

namespace EstatisticaFatec.Controllers
{
    public class DistribuicaoNormalController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new DistribuicaoNormalEntity());
        }

        [HttpPost]
        public ActionResult Index(int mediaPonderada, int desvioPadrao, int cc)
        {
            return View(new DistribuicaoNormalApp().Build(mediaPonderada, desvioPadrao, cc));
        }
    }
}