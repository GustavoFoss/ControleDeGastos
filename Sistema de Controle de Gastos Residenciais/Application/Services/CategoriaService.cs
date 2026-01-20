using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities;
using Sistema_de_Controle_de_Gastos_Residenciais.Infrastructure.Data;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Application.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public void Criar(string descricao, Domain.Enums.FinalidadeCategoria finalidade)
        {
            var categoria = new Categoria(descricao, finalidade);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public IEnumerable<Categoria> Listar()
        {
            return _context.Categorias.ToList();
        }
    }
}
