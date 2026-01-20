using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Enums;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Application.DTOs
{
    public class CategoriaDto
    {
        public string Descricao { get; set; }
        public FinalidadeCategoria Finalidade { get; set; }
    }
}
