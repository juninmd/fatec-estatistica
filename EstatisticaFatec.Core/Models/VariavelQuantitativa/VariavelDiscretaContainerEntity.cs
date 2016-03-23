using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.VariavelQuantitativa
{
    public class VariavelDiscretaContainerEntity
    {
        public VariavelDiscretaContainerEntity()
        {
            Rol = new List<decimal>();
            InputValue = new List<decimal>();
            VariavelQuantitativaEntity = new List<VariavelQuantitativaEntity>();
        }

        /// <summary>
        /// São os registros que foram obtidos pelo input [textarea]
        /// </summary>
        public List<decimal> InputValue { get; set; }

        /// <summary>
        /// Rol é a massa de dados ordenada de forma crescente
        /// </summary>
        public List<decimal> Rol { get; set; }

        /// <summary>
        /// Número que mais se repete
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

        public decimal Variancia { get; set; }

        /// <summary>
        /// Desvio Padrão
        /// </summary>
        public decimal DP { get; set; }

        /// <summary>
        /// Coeficiente da variação
        /// </summary>
        public decimal CV { get; set; }

        public List<VariavelQuantitativaEntity> VariavelQuantitativaEntity { get; set; }
    }
}