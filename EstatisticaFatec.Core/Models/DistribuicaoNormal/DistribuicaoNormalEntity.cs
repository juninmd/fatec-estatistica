namespace EstatisticaFatec.Core.Models.DistribuicaoNormal
{
    public class DistribuicaoNormalEntity
    {
        public int MediaPonderada { get; set; }
        public int DesvioPadrao { get; set; }
        public int CC { get; set; }
        public decimal Propabilidade { get; set; }
        public decimal Soma { get; set; }

    }
}