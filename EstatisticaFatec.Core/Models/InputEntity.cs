namespace EstatisticaFatec.Core.Models
{
    public class InputEntity
    {
        /// <summary>
        /// Input enviado pelo controller
        /// </summary>
        public string MassaDados { get; set; }

        /// <summary>
        /// Tipo de Input enviado 
        /// <para>Amostra</para>
        /// <para>Populacao</para>
        /// </summary>
        public string TipoInput { get; set; }
    }
}
