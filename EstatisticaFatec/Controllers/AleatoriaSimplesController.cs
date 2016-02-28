using EstatisticaFatec.Core;
using EstatisticaFatec.Models.AleatoriaSimples;
using System.Web.Mvc;

namespace EstatisticaFatec.Controllers
{
    public class AleatoriaSimplesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new AleatoriaSimplesEntity());
        }

        [HttpPost]
        public ActionResult Index(int amostra, int populacao)
        {
            return View(new AleatoriaSimplesApp().Build(populacao, amostra));
        }
    }
}