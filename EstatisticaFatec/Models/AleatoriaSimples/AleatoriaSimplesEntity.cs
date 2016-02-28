using System.Collections.Generic;

namespace EstatisticaFatec.Models.AleatoriaSimples
{
    public class AleatoriaSimplesEntity
    {
        public AleatoriaSimplesEntity()
        {
            Resultados = new List<int>();
        }
        public int Amostra { get; set; }
        public int Populacao { get; set; }
        public List<int> Resultados { get; set; }
    }
}