namespace EstatisticaFatec.Core.Models.DistribuicaoUniforme
{
    public class DistribuicaoUniformeEntity
    {
        public DistribuicaoUniformeEntity()
        {
            Input = new decimal?[0];
        }
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal? Equilibrio { get; set; }


        /// <summary>
        /// Valores inputados pelo sistema.
        /// </summary>
        public decimal?[] Input { get; set; }

        /// <summary>
        /// <para>0 - Menor</para>
        /// <para>1 - Entre</para>
        /// <para>2 - Maior</para>
        /// <para>3 - Exatamente</para>
        /// </summary>
        public short TipoEntrada { get; set; }

        public decimal Media { get; set; }
        public decimal DesvioPadrao { get; set; }
        public decimal Variancia { get; set; }
        public decimal? Probabilidade { get; set; }

        /// <summary>
        /// Valor do Range estabelecido pelos inputs
        /// </summary>
        public decimal? X { get; set; }

    }
}
