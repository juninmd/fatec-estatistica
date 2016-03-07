using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoMenor;

namespace EstatisticaFatec.Controllers
{
    public class DistribuicaoMenorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new DistribuicaoMenorEntity());
        }

        [HttpPost]
        public ActionResult Index(int mediaPonderada, int desvioPadrao, int cc)
        {
            return View(new DistribuicaoMenorApp().Build(mediaPonderada, desvioPadrao, cc));
        }
    }
}