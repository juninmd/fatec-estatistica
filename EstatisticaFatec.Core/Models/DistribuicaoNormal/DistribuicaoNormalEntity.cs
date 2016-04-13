namespace EstatisticaFatec.Core.Models.DistribuicaoNormal
{
    public class DistribuicaoNormalEntity
    {
        public DistribuicaoNormalEntity()
        {
            Valor = new[] {new decimal(0), new decimal(0) };
        }
        public int MediaPonderada { get; set; }
        public int DesvioPadrao { get; set; }

        public decimal[] Valor { get; set; }

        /// <summary>
        /// 0 - Menor
        /// 1 - Entre
        /// 2 - Maior
        /// </summary>
        public short TipoEntrada { get; set; }
    }
}