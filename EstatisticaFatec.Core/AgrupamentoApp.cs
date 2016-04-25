using System.Collections.Generic;
using System.Linq;
using EstatisticaFatec.Core.Models.Agrupamento;

namespace EstatisticaFatec.Core
{
    public class AgrupamentoApp
    {
        public List<AgrupamentoEntity> Build(List<decimal> inputData)
        {
            var grupos = inputData.GroupBy(q=> q);
            return grupos.Select(item => new AgrupamentoEntity
            {
                XI = item.Key, Quantidade = item.Count()
            }).ToList();
        }
    }
}
