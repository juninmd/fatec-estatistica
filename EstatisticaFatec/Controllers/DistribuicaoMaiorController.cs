using System.Web.Mvc;

namespace EstatisticaFatec.Controllers
{
    public class DistribuicaoMaiorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int aaa, int bbb, int cc)
        {
            return View();
        }
    }
}