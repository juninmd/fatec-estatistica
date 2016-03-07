namespace EstatisticaFatec.Core.Models.DistribuicaoMenor
{
    public class DistribuicaoMenorEntity
    {
        public int MediaPonderada { get; set; }
        public int DesvioPadrao { get; set; }
        public int CC { get; set; }
        public decimal Propabilidade { get; set; }
        public decimal Soma { get; set; }

    }
}