using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.MedidasTendencia
{
    public class MedidasTendenciaEntity  
    {
        /// <summary>
        /// Números que mais se repetem
        /// </summary>
        public decimal[] Moda { get; set; }

        /// <summary>
        /// Média de todos os números
        /// </summary>
        public decimal Media { get; set; }

        /// <summary>
        /// Calculo da mediana
        /// </summary>
        public decimal Mediana { get; set; }
    }
}