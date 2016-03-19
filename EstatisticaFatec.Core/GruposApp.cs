using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.Grupos;

namespace EstatisticaFatec.Core
{
    public class GruposApp
    {
        public List<GruposEntity> Build(List<decimal> inputData)
        {
            var lista = new List<GruposEntity>();
            var grupos = inputData.GroupBy(q=> q);
            foreach (var item in grupos)
            {
                lista.Add(new GruposEntity
                {
                    XI = item.Key.ToString(),
                    Quantidade = item.Count().ToString()
                });
            }
            return lista;
        }
    }
}
