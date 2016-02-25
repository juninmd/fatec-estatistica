namespace EstatisticaFatec.Models.VariavelContinua
{
    /// <summary>
    /// Classe responsável por listar os Itens da tabela
    /// -> Quantitativa
    /// </summary>
    public class VariavelContinuaEntity
    {
        /// <summary>
        /// [1] - Dado bruto do input
        /// </summary>
        public int XI { get; set; }

        /// <summary>
        /// [2] - Quantidade de elementos [XI]
        /// </summary>
        public int FI { get; set; }

        /// <summary>
        /// [3] - Porcentagem baseando na [quantidade total de FI] sobre o [FI]
        /// </summary>
        public decimal FEPorcent { get; set; }

        /// <summary>
        /// [4] - Números acumulativos sobre [FI]
        /// </summary>
        public int F { get; set; }

        /// <summary>
        /// [5] - Porcentagem acumulativa sobre [FE%]
        /// </summary>
        public decimal FPorcent { get; set; }
    }
}