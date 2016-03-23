using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.VariavelContinua
{
    public class VariavelContinuaContainerEntity
    {
        public VariavelContinuaContainerEntity()
        {
            Rol = new List<decimal>();
            InputValue = new List<decimal>();
            VariavelContinuaEntity = new List<VariavelContinuaEntity>();
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
        /// É o valor mínimo dos inputs [xmin]
        /// </summary>
        public decimal MinLinha { get; set; }

        /// <summary>
        /// É o valor máximo dos inputs [xmax]
        /// </summary>
        public decimal MaxLinha { get; set; }

        /// <summary>
        /// É o valor máximo dos inputs [xmax] menos o valor minimo [xmin] - 1
        /// </summary>
        public decimal AL { get; set; }

        /// <summary>
        /// Indica a raiz quadrada da quantidade (count) do InputValue.
        /// No caso, os resultados aqui serão: K, K+1 e K-1
        /// </summary>
        public List<decimal> K { get; set; }

        /// <summary>
        /// AL (1ª Passo) / K (2ª Passo)
        /// Sendo o AL um numero divisível por algum K, caso não seja o AL é incrementado +1
        /// </summary>
        public decimal IC { get; set; }

        /// <summary>
        /// Número que mais se repete
        /// </summary>
        public decimal Moda { get; set; }

        /// <summary>
        /// Média de todos os números
        /// </summary>
        public decimal Media { get; set; }

        /// <summary>
        /// Calculo da mediana
        /// </summary>
        public decimal Mediana { get; set; }

        /// <summary>
        /// Soma total de XI * FI
        /// </summary>
        public decimal EXIFI { get; set; }

        /// <summary>
        /// Soma total dos FI
        /// </summary>
        public decimal EFI { get; set; }


        public decimal Variancia { get; set; }

        /// <summary>
        /// Desvio Padrão
        /// </summary>
        public decimal DP { get; set; }

        /// <summary>
        /// Coeficiente da variação
        /// </summary>
        public decimal CV { get; set; }

        public List<VariavelContinuaEntity> VariavelContinuaEntity { get; set; }
    }

   
}