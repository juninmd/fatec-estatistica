namespace EstatisticaFatec.Core.Models.DistribuicaoNormal
{
    public class DistribuicaoNormalZEntity
    {
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
    }
}