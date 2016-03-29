using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.EstratificadaUniforme
{
    public class EstratificadaUniformeEntity
    {
        public EstratificadaUniformeEntity()
        {
            Resultados = new List<decimal>();
        }
        public int Amostra { get; set; }
        public int QtdEstrato { get; set; }
        public List<decimal> Resultados { get; set; }
    }
}