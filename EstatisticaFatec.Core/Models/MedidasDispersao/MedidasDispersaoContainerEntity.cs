using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.MedidasDispersao
{
    public class MedidasDispersaoContainerEntity : BaseInputsEntity
    {
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
        /// Atributo com informações da variância / dp / cv 
        /// </summary>
        public MedidasDispersaoEntity MedidasDispersaoEntity { get; set; }
    }
}