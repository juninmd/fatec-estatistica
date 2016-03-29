using EstatisticaFatec.Core.Models.EstratificadaUniforme;
using System;
using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models;

namespace EstatisticaFatec.Core
{
    public class EstratificadaUniformeApp
    {
        public RequestMessage ValidateInput(int amostra, int estratos)
        {
            return new RequestMessage
            {
                IsError = estratos > amostra,
                Message = "A quantidade estratos não deve superar as de amostras."
            };
        }

        public List<decimal> Core(decimal divido, decimal estratos)
        {
            var lista = new List<decimal>();
            var estratificado = new List<decimal>();

            for (int i = 0; i < estratos; i++)
            {
                estratificado.Add(Resto(divido));
                lista.Add(Tratar(divido));
            }
            if (Math.Round(estratificado.Sum(), 2) == 1)
            {
                lista[(int)(estratos - 1)] = lista.Last() + Math.Round(estratificado.Sum(), 2);
                return lista;

            }
            else
            {
                var diff = Math.Round(estratificado.Sum(), 2);
                var divisores = ListaDivisores(diff, estratos);

                if (divisores.IsError)
                {
                    lista[(int)(estratos - 1)] = lista.Last() + Math.Round(estratificado.Sum(), 2);
                    return lista;
                }

                for (int i = 0; i < divisores.Content[1]; i++)
                {
                    lista[i] = lista[i] + divisores.Content[0];

                }
            }
            return lista;
        }

        private RequestMessage<decimal[]> ListaDivisores(decimal diff, decimal estratos)
        {
            while (diff % estratos != 0)
            {
                if (diff % estratos != 0)
                {
                    estratos--;
                }

                if (estratos == 0)
                {
                    return new RequestMessage<decimal[]>
                    {
                        Content = new[] { diff / estratos, estratos },
                        IsError = true
                    };
                }
            }

            return new RequestMessage<decimal[]>
            {
                Content = new[] { diff / estratos, estratos },

            };
        }

        private decimal Resto(decimal numero)
        {
            return numero - (int)numero;
        }
        private decimal Tratar(decimal numero)
        {
            return (int)numero;
        }
        public EstratificadaUniformeEntity Build(int amostra, int estratos)
        {
            return new EstratificadaUniformeEntity
            {
                QtdEstrato = estratos,
                Amostra = amostra,
                Resultados = Core((decimal)amostra / estratos, estratos)
            };
        }
    }
}