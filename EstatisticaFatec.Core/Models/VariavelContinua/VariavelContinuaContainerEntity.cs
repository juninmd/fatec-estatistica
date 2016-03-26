using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.VariavelContinua
{
    public class VariavelContinuaContainerEntity : BaseVariavelQuantitativa
    {
        public VariavelContinuaContainerEntity()
        {
            VariavelContinuaEntity = new List<VariavelContinuaEntity>();
        }

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
        public VariavelContinuaIcEntity IC { get; set; }

        /// <summary>
        /// Soma total de XI * FI
        /// </summary>
        public decimal EXIFI { get; set; }

        /// <summary>
        /// Soma total dos FI
        /// </summary>
        public decimal EFI { get; set; }

        /// <summary>
        /// Lista com informações da tabela
        /// </summary>
        public List<VariavelContinuaEntity> VariavelContinuaEntity { get; set; }
    }
}