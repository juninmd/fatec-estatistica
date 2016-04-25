using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EstatisticaFatec.Core.Models.DistribuicaoNormal;

namespace EstatisticaFatec.Helper
{
    public static class EstatisticaHelper
    {
        public static MvcHtmlString Null(this HtmlHelper h, object item)
        {
            return (item == null || item.ToString() == "0") ? new MvcHtmlString("") : new MvcHtmlString(item.ToString());
        }
        public static MvcHtmlString TakeOnly(this HtmlHelper h, object item, int count = 4)
        {
            return (item == null || item.ToString() == "0") ? new MvcHtmlString("") : new MvcHtmlString(item.ToString().Length > count ? item.ToString().Substring(0, count) : item.ToString());
        }

        public static MvcHtmlString Rol(this HtmlHelper h, List<decimal> inputRol)
        {
            var formatada = string.Join(" - ", inputRol.Select(q => $"[{q}]"));
            return new MvcHtmlString(formatada);
        }
        public static object Rol(this HtmlHelper h, List<int> inputRol)
        {
            var formatada = string.Join(" - ", inputRol.Select(q => $"[{q}]"));
            return new MvcHtmlString(formatada);
        }

        public static MvcHtmlString Moda(this HtmlHelper h, decimal[] moda)
        {
            var formatada = string.Join(" - ", moda.Select(q => $"{q}"));
            return new MvcHtmlString(formatada);
        }
        public static MvcHtmlString FormatacaoObjeto(this HtmlHelper h, List<decimal> input)
        {
            return new MvcHtmlString(string.Join(",", input.Select(q => q.ToString().Replace(",", "."))));
        }

        public static MvcHtmlString FormatacaoObjetoDistribuicaoNormal(this HtmlHelper h, DistribuicaoNormalEntity input)
        {
            switch (input.TipoEntrada)
            {
                case 0:
                    {
                        return new MvcHtmlString($"{input.DistribuicaoNormalZEntity.First().Z.ToString("0.0").Replace(",", ".")},0,{input.MediaPonderada}");
                    }
                case 1:
                    {
                        var min = input.DistribuicaoNormalZEntity.Min(q => q.Z);
                        var max = input.DistribuicaoNormalZEntity.Max(q => q.Z);
                        return new MvcHtmlString($"{min.ToString("0.0").Replace(",", ".")},{max.ToString("0.0").Replace(",", ".")},{input.MediaPonderada}");
                    }
                case 2:
                    {
                        return new MvcHtmlString($"0,{input.DistribuicaoNormalZEntity.First().Z.ToString("0.0").Replace(",", ".")},{input.MediaPonderada}");
                    }
            }
            throw new Exception();
        }
    }
}