using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.Sistematica
{
    public class SistematicaEntity
    {
        public SistematicaEntity()
        {
            Resultado = new List<int>();
        }
        public int Amostra { get; set; }
        public int Inicial { get; set; }
        public int Populacao { get; set; }
        public List<int> Resultado { get; set; }
    }
}