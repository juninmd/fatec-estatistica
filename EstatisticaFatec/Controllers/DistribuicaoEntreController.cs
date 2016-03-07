using System.Web.Mvc;
using EstatisticaFatec.Core.Models.DistribuicaoEntre;

namespace EstatisticaFatec.Controllers
{
    public class DistribuicaoEntreController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new DistribuicaoEntreEntity());
        }

        [HttpPost]
        public ActionResult Index(int aaa, int bbb, int cc)
        {
            return View();
        }
    }
}