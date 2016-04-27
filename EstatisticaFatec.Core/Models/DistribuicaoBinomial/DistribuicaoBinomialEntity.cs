using System;
using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.DistribuicaoBinomial
{
    public class DistribuicaoBinomialEntity
    {
        /// <summary>
        /// Quantidade total de elementos
        /// </summary>
        public decimal N { get; set; }

        /// <summary>
        /// Quantidade de itens com sucesso
        /// </summary>
        public decimal P { get; set; }

        /// <summary>
        /// Quantidade de itens sem sucesso
        /// </summary>
        public decimal Q { get; set; }

        /// <summary>
        /// Lista de elementos K / Probabilidade
        /// </summary>
        public List<Tuple<decimal,decimal>> K { get; set; }

        public decimal ProbabilidadeTotal { get; set; }
    }
}
