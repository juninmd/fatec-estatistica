using System.Collections.Generic;

namespace EstatisticaFatec.Models
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            ValorBrutoOrdenado = new List<int>();
            ValorBruto = new List<int>();

        }
        public List<int> ValorBruto { get; set; }
        public List<int> ValorBrutoOrdenado { get; set; }
    }
}