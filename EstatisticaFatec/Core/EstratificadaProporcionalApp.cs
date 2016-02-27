using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstatisticaFatec.Models.EstratificadaProporcional;

namespace EstatisticaFatec.Core
{
    public class EstratificadaProporcionalApp
    {
        public List<EstratificadaProporcionalEntity> Build(int amostra, List<int> estratos, int populacao)
        {
            var porTotal = (decimal)amostra / populacao;
            var countEstratos = estratos.Count();

            var lista = new List<EstratificadaProporcionalEntity>();

            for (int i = 0; i < countEstratos; i++)
            {
                var qtdFinal = (int)Math.Round(porTotal * estratos[i]);

                lista.Add(new EstratificadaProporcionalEntity
                {
                    IdEstrato = i,
                    QtdEstrato = qtdFinal
                });
            }
            return lista;
        }
    }
    
}
