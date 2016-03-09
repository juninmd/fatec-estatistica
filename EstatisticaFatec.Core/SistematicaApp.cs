using System;
using System.Collections.Generic;
using EstatisticaFatec.Core.Models.Sistematica;

namespace EstatisticaFatec.Core
{
    public class SistematicaApp
    {
        public SistematicaEntity Build(int amostra, int inicial, int populacao)
        {
            var inicicalOriginal = inicial;
            var repeticao = (int)Math.Round(populacao / (decimal)amostra);
            var rolSistematica = new List<int> {};

            while (inicial < populacao)
            {
                rolSistematica.Add(inicial);
                inicial = inicial + repeticao;
            }

            return new SistematicaEntity
            {
                Resultado = rolSistematica,
                Amostra = amostra,
                Inicial = inicicalOriginal,
                Populacao = populacao
            };
        }
    }
}