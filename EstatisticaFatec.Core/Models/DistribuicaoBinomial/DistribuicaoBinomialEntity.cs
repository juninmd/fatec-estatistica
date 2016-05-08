using System;
using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.DistribuicaoBinomial
{
    public class DistribuicaoBinomialEntity
    {
        public DistribuicaoBinomialEntity()
        {
            KProbabilidade = new List<decimal[]>();
        }


        /// <summary>
        /// <para>true - Resultado deve ser em torno das com sucesso</para>
        /// <para>false - Resultado deve ser em torno das sem sucesso</para>
        /// </summary>
        public bool InputSemDefeito { get; set; }

        /// <summary>
        /// Quantidade total de elementos
        /// </summary>
        public decimal N { get; set; }


        /// <summary>
        /// Quantidade de itens com sucesso
        /// </summary>
        public decimal SucessoInput { get; set; }

        /// <summary>
        /// Quantidade de itens com sucesso
        /// </summary>
        public decimal P { get; set; }

        /// <summary>
        /// Quantidade de itens sem sucesso     [ Fracasso ] 
        /// </summary>
        public decimal Q { get; set; }

        /// <summary>
        /// <para>0 - Menor</para>
        /// <para>1 - Exatamente</para>
        /// <para>2 - Maior</para>
        /// </summary>
        public short TipoEntrada { get; set; }


        /// <summary>
        /// Item no Input
        /// </summary>
        public int KInput { get; set; }

        /// <summary>
        /// Lista de elementos K / Probabilidade
        /// </summary>
        public List<int> K { get; set; }

        public List<decimal[]> KProbabilidade { get; set; }

        public decimal Media { get; set; }
        public double DesvioPadrao { get; set; }
    }
}
