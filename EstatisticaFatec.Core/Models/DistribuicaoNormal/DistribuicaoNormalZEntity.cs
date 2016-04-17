using System;

namespace EstatisticaFatec.Core.Models.DistribuicaoNormal
{
    public class DistribuicaoNormalZEntity
    {
        public DistribuicaoNormalZEntity()
        {

        }
        /// <summary>
        /// Valor Original
        /// </summary>
        public decimal ValorOriginal { get; set; }

        /// <summary>
        /// Valor Z da Distribuição
        /// </summary>
        public decimal Z { get; set; }

        /// <summary>
        /// Valor Z na tabela
        /// </summary>
        public decimal ValorTabela { get; set; }

        /// <summary>
        /// É maior que a média?
        /// </summary>
        public bool IsBigger { get; set; }

        public decimal Probabilidade
        {
            get
            {
                return IsBigger
                    ? Math.Round((ValorTabela > 0 ? Z - ValorTabela : ValorTabela - ValorTabela)*100, 2)
                    : Math.Round((ValorTabela > 0 ? Z + ValorTabela : ValorTabela + ValorTabela)*100, 2);
            }
        }
    }
}