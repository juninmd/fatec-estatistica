using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.VariavelDiscreta
{
    public class VariavelDiscretaContainerEntity : BaseVariavelQuantitativa
    {
        public VariavelDiscretaContainerEntity()
        {
            VariavelDiscretaEntity = new List<VariavelDiscretaEntity>();
        }

        /// <summary>
        /// Lista com a tabela 
        /// </summary>
        public List<VariavelDiscretaEntity> VariavelDiscretaEntity { get; set; }
     
    }
}