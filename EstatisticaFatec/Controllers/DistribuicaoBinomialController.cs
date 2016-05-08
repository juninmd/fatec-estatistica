using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoBinomial;

namespace EstatisticaFatec.Controllers
{
    public class DistribuicaoBinomialController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new DistribuicaoBinomialEntity());
        }

        [HttpPost]
        public ActionResult Index(DistribuicaoBinomialEntity distribuicao, FormCollection form)
        {
            return View(new DistribuicaoBinomialApp().Build(distribuicao));
        }
    }
}