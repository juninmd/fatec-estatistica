namespace EstatisticaFatec.Core.Models.VariavelDiscreta
{
    /// <summary>
    /// Classe responsável por listar os Itens da tabela
    /// -> Discreta
    /// </summary>
    public class VariavelDiscretaEntity
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
        public decimal XIFI { get; set; }

        /// <summary>
        /// [7] - (XI - MÉDIA)². FI
        /// </summary>
        public XIFIQuadFI XIFIQuadFI { get; set; }

        /// <summary>
        /// [8] - Probabilidade
        /// </summary>
        public decimal Probabilidade { get; set; }
    }

    public class XIFIQuadFI
    {
        public string Formula { get; set; }
        public decimal Valor { get; set; }
    }
}