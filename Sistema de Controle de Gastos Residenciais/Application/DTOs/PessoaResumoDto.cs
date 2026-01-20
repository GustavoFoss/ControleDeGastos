namespace Sistema_de_Controle_de_Gastos_Residenciais.Application.DTOs
{
    public class PessoaResumoDto
    {
        public string Nome { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo => TotalReceitas - TotalDespesas;
    }
}
