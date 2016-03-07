using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.VariavelQuantitativa
{
    public class VariavelDiscretaContainerEntity
    {
        public VariavelDiscretaContainerEntity()
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

        /// <summary>
        /// Número que mais se repete
        /// </summary>
        public int Moda { get; set; }

        /// <summary>
        /// Média de todos os números
        /// </summary>
        public decimal Media { get; set; }

        /// <summary>
        /// Calculo da mediana
        /// </summary>
        public int Mediana { get; set; }

        public List<VariavelQuantitativaEntity> VariavelQuantitativaEntity { get; set; }
    }
}