using System;
using System.Collections.Generic;
using System.Linq;

namespace EstatisticaFatec.Core
{
    public class SistematicaApp
    {
        public string Build(int amostra, int inicial, int populacao)
        {
            var repeticao = (int)Math.Round(populacao / (decimal)amostra);
            var rolSistematica = new List<int> {inicial};

            for (var i = 1; i < amostra; i++)
            {
                rolSistematica.Add(inicial + repeticao);
            }

            return string.Join(";", rolSistematica);
        }
    }
}