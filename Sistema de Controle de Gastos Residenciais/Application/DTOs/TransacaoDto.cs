using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Enums;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Application.DTOs
{
    public class TransacaoDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public Guid PessoaId { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
