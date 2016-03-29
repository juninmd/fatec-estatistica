using System;
using System.Collections.Generic;
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.Sistematica;

namespace EstatisticaFatec.Core
{
    public class SistematicaApp
    {
        public RequestMessage ValidateInput(int amostra, int inicial, int populacao)
        {
            if (amostra > populacao)
            {
                return new RequestMessage
                {
                    IsError = true,
                    Message = "A amostra não pode ser maior que a população."
                };
            }
            else if (amostra > 1 && inicial == populacao)
            {
                return new RequestMessage
                {
                    IsError = true,
                    Message = "A amostra possui uma quantidade superior aos parâmetros de população."
                };
            }
            else if (inicial > populacao)
            {
                return new RequestMessage
                {
                    IsError = true,
                    Message = "O valor inicial é maior que a população."
                };
            }

            return new RequestMessage();

        }

        public SistematicaEntity Build(int amostra, int inicial, int populacao)
        {
            var inicicalOriginal = inicial;
            var repeticao = (decimal)Math.Round(populacao / (decimal)amostra);
            var rolSistematica = new List<int> { };

            if (inicial == populacao && amostra == 1)
            {
                rolSistematica.Add(inicial);
            }
            else
            {
                while (inicial < populacao)
                {
                    rolSistematica.Add(inicial);
                    inicial = (int)(inicial + repeticao);
                }
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