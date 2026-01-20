using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Exceptions;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities
{
    public class Pessoa
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public ICollection<Transacao> Transacoes { get; private set; }

        protected Pessoa() { }

        public Pessoa(string nome, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome é obrigatório.");

            if (idade <= 0)
                throw new DomainException("Idade deve ser um número positivo.");

            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
            Transacoes = new List<Transacao>();
        }
    }
}
