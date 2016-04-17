using System;

namespace EstatisticaFatec.Core.Const
{
    public class TabelaDistribuicao
    {
        public decimal Calcular(decimal Z)
        {
            var att = TratarResultado(Math.Abs(Z));
            return new ColunaTabelaDistribuicao(att.Item1, att.Item2).GetLinha();
        }
        private Tuple<decimal, decimal> TratarResultado(decimal item)
        {
            var bruto = item.ToString("0.0|00").Split(',', '|'); // 1,00
            var coluna = decimal.Parse(bruto[0] + "," + bruto[1]).ToString("0.0");
            return new Tuple<decimal, decimal>(decimal.Parse(coluna), decimal.Parse(bruto[2]));
        }
    }

}
