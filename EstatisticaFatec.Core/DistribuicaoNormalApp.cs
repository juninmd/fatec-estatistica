
using EstatisticaFatec.Core.Models;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;

namespace EstatisticaFatec.Core
{
    public class DistribuicaoNormalApp
    {
        public DistribuicaoNormalEntity Build(DistribuicaoNormalEntity distribuicao)
        {
            foreach (var item in distribuicao.Valor)
            {
                var Z = CalcularZ(item, distribuicao.MediaPonderada, distribuicao.DesvioPadrao);
            }
            return distribuicao;
        }

        private decimal CalcularZ(decimal valor, decimal media, decimal desvioPadrao)
        {
            return (valor - media) / desvioPadrao;
        }
        private decimal Tabela(decimal z)
        {
            return 0;
        }
    }
}
