using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Models;

namespace EstatisticaFatec.Controllers
{
    public class VariavelQuantitativaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new EntidadeBase());
        }

        [HttpPost]
        public ActionResult Index(string massaDados)
        {

            var lista = massaDados.Split(',').Select(int.Parse).ToList();

            var entidade = new EntidadeBase
            {
                ValorBruto = lista,
                ValorBrutoOrdenado = lista.OrderBy(x=> x).ToList()
            };

            return View(entidade);
        }
    }
}