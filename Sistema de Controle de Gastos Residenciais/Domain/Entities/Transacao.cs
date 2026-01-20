using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Enums;
using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Exceptions;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities
{
    public class Transacao
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public TipoTransacao Tipo { get; private set; }

        public Guid PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }

        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Transacao() { }

        public Transacao(
            string descricao,
            decimal valor,
            TipoTransacao tipo,
            Pessoa pessoa,
            Categoria categoria)
        {
            if (valor <= 0)
                throw new DomainException("O valor da transação deve ser positivo.");

            // Regra: menor de idade não pode registrar receitas
            if (pessoa.Idade < 18 && tipo == TipoTransacao.Receita)
                throw new DomainException("Menores de idade não podem registrar receitas.");

            // Regra: categoria deve permitir o tipo de transação
            if (categoria.Finalidade == FinalidadeCategoria.Despesa && tipo == TipoTransacao.Receita ||
                categoria.Finalidade == FinalidadeCategoria.Receita && tipo == TipoTransacao.Despesa)
                throw new DomainException("Categoria incompatível com o tipo da transação.");

            Id = Guid.NewGuid();
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
            Pessoa = pessoa;
            Categoria = categoria;
            PessoaId = pessoa.Id;
            CategoriaId = categoria.Id;
        }
    }
}
