using System.Collections.Generic;

namespace EstatisticaFatec.Core.Models.DistribuicaoNormal
{
    public class DistribuicaoNormalEntity
    {
        public DistribuicaoNormalEntity()
        {
            Valor = new decimal?[] {};
            DistribuicaoNormalZEntity = new List<DistribuicaoNormalZEntity>();
        }
        public decimal MediaPonderada { get; set; }
        public decimal DesvioPadrao { get; set; }

        public decimal?[] Valor { get; set; }

        /// <summary>
        /// <para>0 - Menor</para>
        /// <para>1 - Entre</para>
        /// <para>2 - Maior</para>
        /// </summary>
        public short TipoEntrada { get; set; }

        public List<DistribuicaoNormalZEntity> DistribuicaoNormalZEntity { get; set; }


        /// <summary>
        /// Final
        /// </summary>
        public decimal Probabilidade { get; set; }


    }
}