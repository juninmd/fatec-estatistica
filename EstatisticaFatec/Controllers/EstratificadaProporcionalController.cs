using EstatisticaFatec.Core;
using System.Collections.Generic;
using System.Web.Mvc;
using EstatisticaFatec.Core.Models.EstratificadaProporcional;

namespace EstatisticaFatec.Controllers
{
    public class EstratificadaProporcionalController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new EstratificadaProporcionalContainerEntity());
        }

        [HttpPost]
        public ActionResult Index(int amostra, List<int> estrato, int populacao)
        {
            return View(new EstratificadaProporcionalApp().Build(amostra, estrato, populacao));
        }
    }
}