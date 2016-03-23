using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.MedidasDispersao
{
    public class MedidasDispersaoEntity
    {
        public MedidasDispersaoEntity()
        {
            InputValueQuadrado = new List<decimal>();
            InputValue = new List<decimal>();
            Rol = new List<decimal>();
        }

        /// <summary>
        /// Inputs recebidos
        /// </summary>
        public List<decimal> InputValue { get; set; }

        /// <summary>
        /// Ordenação dos itens
        /// </summary>
        public List<decimal> Rol { get; set; }

        /// <summary>
        /// Soma de todos os inputs / quantidade dos inputs
        /// </summary>
        public decimal Media { get; set; }

        /// <summary>
        /// XI - Média = Parte [variância]
        /// </summary>
        public List<decimal> InputValueQuadrado { get; set; }


        /// <summary>
        /// Soma de todos os XI [InputValueQuadrado]
        /// </summary>
        public decimal SomaInputValueQuadrado { get; set; }

        /// <summary>
        /// <para>V(X)²</para>
        /// <para>[SomaInputValueQuadrado/SomaInputValueQuadrado.length - 1] = X(V)</para>
        /// </summary>
        public decimal Variancia { get; set; }

        /// <summary>
        /// raiz[Variancia]
        /// </summary>
        public decimal DP { get; set; }

        /// <summary>
        /// (DP/Media) * 100 = Porcentagem
        /// </summary>
        public decimal CV { get; set; }
    }
}