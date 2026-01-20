using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Enums;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public FinalidadeCategoria Finalidade { get; private set; }

        protected Categoria() { }

        public Categoria(string descricao, FinalidadeCategoria finalidade)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Finalidade = finalidade;
        }
    }
}
