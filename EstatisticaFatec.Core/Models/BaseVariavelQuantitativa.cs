using System.Collections.Generic;
using EstatisticaFatec.Core.Models.Grupos;
using EstatisticaFatec.Core.Models.MedidasDispersao;
using EstatisticaFatec.Core.Models.MedidasTendencia;

namespace EstatisticaFatec.Core.Models
{
    public class BaseVariavelQuantitativa: BaseInputsEntity
    {
        /// <summary>
        /// Medidas de dispersão
        /// </summary>
        public MedidasDispersaoEntity MedidasDispersaoEntity { get; set; }

        /// <summary>
        /// Medidas de tendência
        /// </summary>
        public MedidasTendenciaEntity MedidasTendenciaEntity { get; set; }

        /// <summary>
        /// Número inputado e Quantidade de vezes que aparece
        /// </summary>
        public List<AgrupamentoEntity> AgrupamentoEntity { get; set; }
    }
}
