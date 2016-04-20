using System;
using System.Collections.Generic;
using EstatisticaFatec.Core;
using EstatisticaFatec.Core.Const;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstatisticaFatec.Tests
{
    [TestClass]
    public class TabelaDistribuicaoNormalTest
    {
        private TabelaDistribuicao TabelaDistribuicao => new TabelaDistribuicao();

        public Tuple<decimal, decimal> Add(double a, double b)
        {
            return new Tuple<decimal, decimal>(decimal.Parse(a.ToString()), decimal.Parse(b.ToString()));
        }

        [TestMethod]
        public void ValidandoTabela()
        {
            var lista = new List<Tuple<decimal, decimal>>
            {
                Add(0, 0.0000),
                Add(0.01, 0.0040),
                Add(0.02, 0.0080),
                Add(0.03, 0.0120),
                Add(0.04, 0.0160),
                Add(0.05, 0.0199),
                Add(0.06, 0.0239),
                Add(0.07, 0.0279),
                Add(0.08, 0.0319),
                Add(0.09, 0.0359),

                Add(0.10, 0.0398),
                Add(0.11, 0.0438),
                Add(0.12, 0.0478),
                Add(0.13, 0.0517),
                Add(0.14, 0.0557),
                Add(0.15, 0.0596),
                Add(0.16, 0.0636),
                Add(0.17, 0.0675),
                Add(0.18, 0.0714),
                Add(0.19, 0.0753),

                Add(0.20, 0.0793),
                Add(0.21, 0.0832),
                Add(0.22, 0.0871),
                Add(0.23, 0.0910),
                Add(0.24, 0.0948),
                Add(0.25, 0.0987),
                Add(0.26, 0.1026),
                Add(0.27, 0.1064),
                Add(0.28, 0.1103),
                Add(0.29, 0.1141),

                Add(0.30, 0.1179),
                Add(0.31, 0.1217),
                Add(0.32, 0.1255),
                Add(0.33, 0.1293),
                Add(0.34, 0.1331),
                Add(0.35, 0.1368),
                Add(0.36, 0.1406),
                Add(0.37, 0.1443),
                Add(0.38, 0.1480),
                Add(0.39, 0.1517),

                Add(0.40, 0.1554),
                Add(0.41, 0.1591),
                Add(0.42, 0.1628),
                Add(0.43, 0.1664),
                Add(0.44, 0.1700),
                Add(0.45, 0.1736),
                Add(0.46, 0.1772),
                Add(0.47, 0.1808),
                Add(0.48, 0.1844),
                Add(0.49, 0.1879),

                Add(0.50, 0.1915),
                Add(0.51, 0.1950),
                Add(0.52, 0.1985),
                Add(0.53, 0.2019),
                Add(0.54, 0.2054),
                Add(0.55, 0.2088),
                Add(0.56, 0.2123),
                Add(0.57, 0.2157),
                Add(0.58, 0.2190),
                Add(0.59, 0.2224),

                Add(0.60, 0.2257),
                Add(0.61, 0.2291),
                Add(0.62, 0.2324),
                Add(0.63, 0.2357),
                Add(0.64, 0.2389),
                Add(0.65, 0.2422),
                Add(0.66, 0.2454),
                Add(0.67, 0.2486),
                Add(0.68, 0.2517),
                Add(0.69, 0.2549),

                Add(0.70, 0.2580),
                Add(0.71, 0.2611),
                Add(0.72, 0.2642),
                Add(0.73, 0.2673),
                Add(0.74, 0.2704),
                Add(0.75, 0.2734),
                Add(0.76, 0.2764),
                Add(0.77, 0.2794), 
                Add(0.78, 0.2823),
                Add(0.79, 0.2852),


                Add(0.80, 0.2881),
                Add(0.81, 0.2910),
                Add(0.82, 0.2939),
                Add(0.83, 0.2967),
                Add(0.84, 0.2995),
                Add(0.85, 0.3023),
                Add(0.86, 0.3051),
                Add(0.87, 0.3078),
                Add(0.88, 0.3106),
                Add(0.89, 0.3133),

                Add(0.90, 0.3159),
                Add(0.91, 0.3186),
                Add(0.92, 0.3212),
                Add(0.93, 0.3238),
                Add(0.94, 0.3264),
                Add(0.95, 0.3289),
                Add(0.96, 0.3315),
                Add(0.97, 0.3340),
                Add(0.98, 0.3365),
                Add(0.99, 0.3389),

                Add(1.00, 0.3413),
                Add(1.01, 0.3438),
                Add(1.02, 0.3461),
                Add(1.03, 0.3485),
                Add(1.04, 0.3508),
                Add(1.05, 0.3531),
                Add(1.06, 0.3554),
                Add(1.07, 0.3577),
                Add(1.08, 0.3599),
                Add(1.09, 0.3621),

                Add(1.00, 0.3413),
                Add(1.01, 0.3438),
                Add(1.02, 0.3461),
                Add(1.03, 0.3485),
                Add(1.04, 0.3508),
                Add(1.05, 0.3531),
                Add(1.06, 0.3554),
                Add(1.07, 0.3577),
                Add(1.08, 0.3599),
                Add(1.09, 0.3621),

           };

            foreach (var item in lista)
            {
                var calc = TabelaDistribuicao.Calcular(item.Item1);

                Assert.IsTrue(calc == item.Item2, $"Cálculo para {item.Item1}: {calc} != {item.Item2}");
            }
        }
    }
}
