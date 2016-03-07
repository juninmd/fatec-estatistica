using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.EstratificadaProporcional;

namespace EstatisticaFatec.Core
{
    public class EstratificadaProporcionalApp
    {
        public EstratificadaProporcionalContainerEntity Build(int amostra, List<int> estratos, int populacao)
        {
            var porTotal = (decimal)populacao / amostra;
            var countEstratos = estratos.Count();

            var lista = new List<EstratificadaProporcionalEntity>();

            for (int i = 0; i < countEstratos; i++)
            {
                var qtdFinal = (int)Math.Round((decimal)porTotal * (decimal)estratos[i]);

                lista.Add(new EstratificadaProporcionalEntity
                {
                    IdEstrato = i,
                    QtdEstrato = qtdFinal
                });
            }
            return new EstratificadaProporcionalContainerEntity()
            {
                Amostra = amostra,
                Populacao = populacao,
                ListaEstratos = estratos,
                EstratificadaProporcional = lista
            };
        }
    }

}
