using EstatisticaFatec.Core;
using EstatisticaFatec.Models.Estratificada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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