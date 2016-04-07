using System.Collections.Generic;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class VariavelContinuaTest
    {
        [TestMethod]
        public void Input()
        {
            var baseInput = new BaseInputsEntity
            {
                InputValue = new List<decimal>()
                {
                 3,
                 4,
                 new decimal(3.5),
                 5,
                 new decimal(3.5),
                 4,
                 5,
                 new decimal(5.5),
                 4,
                 5
                 }
            };

            var responseLista = new VariavelContinuaApp().Build(baseInput);


            var baseInputNew = new BaseInputsEntity
            {
                InputValue = new List<decimal>
                {
                    20,37,40,32,28,26,25,32,39,40,50,47,46,31,24,21,35,39,38,43
                }
            };


            var lista = new VariavelContinuaApp().Build(baseInputNew);
        }
    }
}
