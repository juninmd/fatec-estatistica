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
            return View(new DistribuicaoNormalContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(DistribuicaoNormalContainerEntity distribuicao)
        {
         

            return View(new DistribuicaoNormalApp().Build(distribuicao));
        }
    }
}