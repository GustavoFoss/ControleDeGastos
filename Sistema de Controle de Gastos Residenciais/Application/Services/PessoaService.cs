using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities;
using Sistema_de_Controle_de_Gastos_Residenciais.Infrastructure.Data;

namespace SistemaDeControleDeGastosResidenciais.Application.Services
{
    public class PessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        public void Criar(string nome, int idade)
        {
            var pessoa = new Pessoa(nome, idade);
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public IEnumerable<Pessoa> Listar()
        {
            return _context.Pessoas.ToList();
        }

        public void Deletar(Guid id)
        {
            var pessoa = _context.Pessoas.Find(id);
            if (pessoa == null) return;

            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}
