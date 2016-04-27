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
        /// 
        /// </summary>
        public decimal PInput { get; set; }

        /// <summary>
        /// Quantidade de itens com sucesso
        /// </summary>
        public decimal P { get; set; }

        /// <summary>
        /// Quantidade de itens sem sucesso     [ Fracasso ] 
        /// </summary>
        public decimal Q { get; set; }

         
        /// <summary>
        /// 
        /// </summary>
        public decimal QInput { get; set; }

        /// <summary>
        /// <para>true - Resultado deve ser em torno das com sucesso</para>
        /// <para>false - Resultado deve ser em torno das sem sucesso</para>
        /// </summary>
        public bool InputSemDefeito { get; set; }

        /// <summary>
        /// <para>0 - Menor</para>
        /// <para>1 - Exatamente</para>
        /// <para>2 - Maior</para>
        /// </summary>
        public short TipoEntrada { get; set; }


        /// <summary>
        /// Item no Input
        /// </summary>
        public decimal KInput { get; set; }

        /// <summary>
        /// Lista de elementos K / Probabilidade
        /// </summary>
        public List<Tuple<decimal,decimal>> K { get; set; }

        public decimal ProbabilidadeTotal { get; set; }
    }
}
