
using EstatisticaFatec.Core.Models.DistribuicaoNormal;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoNormalApp
    {
        public DistribuicaoNormalEntity Build(int mediaPonderada, int desvioPadrao, int cc)
        {
            var Propabilidade = (((decimal)cc - (decimal)mediaPonderada) / (decimal)desvioPadrao);

            var soma = Soma(mediaPonderada, cc, desvioPadrao);

            return new DistribuicaoNormalEntity
            {
                CC = cc,
                DesvioPadrao = desvioPadrao,
                MediaPonderada = mediaPonderada,
                Propabilidade = Propabilidade,
                Soma = soma

            };
        }



        private decimal Soma(int mediaPonderada, int cc, decimal table)
        {
            var soma = new decimal(0);
            if (cc < mediaPonderada)
            {
                soma = table - new decimal(0.5);
                soma = soma * 100;
            }
            else if (cc > mediaPonderada)
            {
                soma = table + new decimal(0.5);
                soma = soma * 100;
            }
            else if (cc == mediaPonderada)
            {
                soma = new decimal(0.5);
                soma = soma * 100;
            }
            if (cc < 0)
            {
                soma = soma * -1;
            }
            return soma;
        }
    }
}
