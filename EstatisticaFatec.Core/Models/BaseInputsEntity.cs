using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models
{
    public class BaseInputsEntity
    {
        public BaseInputsEntity()
        {
            InputValue = new List<decimal>();
            Rol = new List<decimal>();
        }
        /// <summary>
        /// São os registros que foram obtidos pelo input [textarea]
        /// </summary>
        public List<decimal> InputValue { get; set; }

        /// <summary>
        /// Rol é a massa de dados ordenada de forma crescente
        /// </summary>
        public List<decimal> Rol { get; set; }
    }
}
