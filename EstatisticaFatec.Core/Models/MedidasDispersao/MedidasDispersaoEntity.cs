namespace EstatisticaFatec.Core.Models.MedidasDispersao
{
    public class MedidasDispersaoEntity
    {
      
        /// <summary>
        /// <para>V(X)²</para>
        /// <para>[SomaInputValueQuadrado/SomaInputValueQuadrado.length - 1] = X(V)</para>
        /// </summary>
        public decimal Variancia { get; set; }

        /// <summary>
        /// raiz[Variancia]
        /// </summary>
        public decimal DP { get; set; }

        /// <summary>
        /// (DP/Media) * 100 = Porcentagem
        /// </summary>
        public decimal CV { get; set; }
    }
}