namespace EstatisticaFatec.Models.VariavelContinua
{
    /// <summary>
    /// Classe responsável por listar os Itens da tabela
    /// -> Quantitativa
    /// </summary>
    public class VariavelContinuaEntity
    {
        /// <summary>
        /// [1] - Indice da classe [1][2][3][4]
        /// </summary>
        public int Classe { get; set; }

        /// <summary>
        /// [2] - Range de [x] para [y]
        /// </summary>
        public int[] Range { get; set; }

        /// <summary>
        /// [3] Contagens
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// [4] - Porcentagem baseando na [quantidade total de FI] sobre o [FI]
        /// </summary>
        public decimal FEPorcent { get; set; }

        /// <summary>
        /// [5] - Números acumulativos sobre [FI]
        /// </summary>
        public int F { get; set; }

        /// <summary>
        /// [6] - Porcentagem acumulativa sobre [FE%]
        /// </summary>
        public decimal FPorcent { get; set; }
    }
}