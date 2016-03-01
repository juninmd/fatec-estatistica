using System.Collections.Generic;

namespace EstatisticaFatec.Models.Sistematica
{
    public class SistematicaEntity
    {
        public int Amostra { get; set; }
        public int Inicial { get; set; }
        public int Populacao { get; set; }
        public List<int> Resultado { get; set; }
    }
}