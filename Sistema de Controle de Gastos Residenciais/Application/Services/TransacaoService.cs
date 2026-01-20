using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities;
using Sistema_de_Controle_de_Gastos_Residenciais.Infrastructure.Data;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Application.Services
{
    public class TransacaoService
    {
        private readonly AppDbContext _context;

        public TransacaoService(AppDbContext context)
        {
            _context = context;
        }

        public void Criar(string descricao, decimal valor, Domain.Enums.TipoTransacao tipo, System.Guid pessoaId, System.Guid categoriaId)
        {
            var pessoa = _context.Pessoas.Find(pessoaId);
            var categoria = _context.Categorias.Find(categoriaId);

            var transacao = new Transacao(descricao, valor, tipo, pessoa, categoria);
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }

        public IEnumerable<Transacao> Listar()
        {
            return _context.Transacoes
                .Include(t => t.Pessoa)
                .Include(t => t.Categoria)
                .ToList();
        }
    }
}
