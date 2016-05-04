using System.Web.Mvc;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models.DistribuicaoUniforme;

namespace EstatisticaFatec.Controllers
{
    public class DistribuicaoUniformeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new DistribuicaoUniformeEntity());
        }

        [HttpPost]
        public ActionResult Index(DistribuicaoUniformeEntity distribuicao)
        {
            return View(new DistribuicaoUniformeApp().Build(distribuicao));
        }
    }
}