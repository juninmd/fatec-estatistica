namespace EstatisticaFatec.Core.Models.VariavelContinua
{
    /// <summary>
    /// Classe responsável pelo intervalo de classes
    /// </summary>
    public class VariavelContinuaIcEntity
    {
        /// <summary>
        /// Intervalo de uma Linha para outra 
        /// [x]-----------[y]
        /// </summary>
        public decimal IC { get; set; }

        /// <summary>
        /// Quantidade de Linhas
        /// [x]-----------[y]
        /// [x]-----------[y]
        /// [x]-----------[y]
        /// [x]-----------[y]
        /// </summary>
        public int Classes { get; set; }
    }
}