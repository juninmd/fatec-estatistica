using System.Collections.Generic;

namespace EstatisticaFatec.Models.VariavelQuantitativa
{
    public class VariavelQuantitativaContainerEntity
    {
        public VariavelQuantitativaContainerEntity()
        {
            Rol = new List<int>();
            InputValue = new List<int>();
            VariavelQuantitativaEntity = new List<VariavelQuantitativaEntity>();
        }

        /// <summary>
        /// São os registros que foram obtidos pelo input [textarea]
        /// </summary>
        public List<int> InputValue { get; set; }

        /// <summary>
        /// Rol é a massa de dados ordenada de forma crescente
        /// </summary>
        public List<int> Rol { get; set; }


        public List<VariavelQuantitativaEntity> VariavelQuantitativaEntity { get; set; }
    }
}