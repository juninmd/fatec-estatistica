using System;
using System.Collections.Generic;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.Sistematica;

namespace EstatisticaFatec.Core
{
    public class SistematicaApp
    {
        public RequestMessage ValidateInput(int amostra, int populacao)
        {
            return new RequestMessage
            {
                IsError = amostra > populacao,
                Message = "A amostra não pode ser maior que a população."
            };
        }

        public SistematicaEntity Build(int amostra, int inicial, int populacao)
        {
            var inicicalOriginal = inicial;
            var repeticao = (decimal)Math.Round(populacao / (decimal)amostra);
            var rolSistematica = new List<int> {};

            while (inicial < populacao)
            {
                rolSistematica.Add(inicial);
                inicial = (int) (inicial + repeticao);
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