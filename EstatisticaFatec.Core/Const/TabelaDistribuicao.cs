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
        private Tuple<decimal, int> TratarResultado(decimal item)
        {
            var bruto = item.ToString("0.00"); // 1,00

            var coluna = decimal.Parse(bruto.Substring(0, 3)).ToString("0.0");
            var linha = bruto.Substring(3, 1);
            return new Tuple<decimal, int>(decimal.Parse(coluna), int.Parse(linha));
        }
    }

}
