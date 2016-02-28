using EstatisticaFatec.Models.EstratificadaProporcional;
using System.Collections.Generic;

namespace EstatisticaFatec.Models.Estratificada
{
    public class EstratificadaProporcionalContainerEntity
    {
        public EstratificadaProporcionalContainerEntity()
        {
            EstratificadaProporcional = new List<EstratificadaProporcionalEntity>();
            ListaEstratos = new List<int>();
        }
        public List<EstratificadaProporcionalEntity> EstratificadaProporcional { get; set; }
      
        public int Amostra { get; set; }
        public int Populacao { get; set; }
        public List<int> ListaEstratos { get; set; }
    }
}