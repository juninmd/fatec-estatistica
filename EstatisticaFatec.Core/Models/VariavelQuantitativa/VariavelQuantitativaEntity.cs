namespace EstatisticaFatec.Core.Models.VariavelQuantitativa
{
    /// <summary>
    /// Classe responsável por listar os Itens da tabela
    /// -> Quantitativa
    /// </summary>
    public class VariavelQuantitativaEntity
    {
        /// <summary>
        /// [1] - Dado bruto do input
        /// </summary>
        public decimal XI { get; set; }

        /// <summary>
        /// [2] - Quantidade de elementos [XI]
        /// </summary>
        public decimal FI { get; set; }

        /// <summary>
        /// [3] - Porcentagem baseando na [quantidade total de FI] sobre o [FI]
        /// </summary>
        public decimal FEPorcent { get; set; }

        /// <summary>
        /// [4] - Números acumulativos sobre [FI]
        /// </summary>
        public decimal F { get; set; }

        /// <summary>
        /// [5] - Porcentagem acumulativa sobre [FE%]
        /// </summary>
        public decimal FPorcent { get; set; }

        /// <summary>
        /// [6] - XI * FI
        /// </summary>
        public decimal Media { get; set; }
    }
}