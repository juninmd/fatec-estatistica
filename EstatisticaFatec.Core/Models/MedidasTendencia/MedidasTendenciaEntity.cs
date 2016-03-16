using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.MedidasTendencia
{
    public class MedidasTendenciaEntity
    {
        public MedidasTendenciaEntity()
        {
            InputValue = new List<decimal>();
            Rol = new List<decimal>();
        }
        public List<decimal> InputValue { get; set; }
        public List<decimal> Rol { get; set; }
        public decimal Moda { get; set; }
        public decimal Mediana { get; set; }
        public decimal Media { get; set; }
    }
}