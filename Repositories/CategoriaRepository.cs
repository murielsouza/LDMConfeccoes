using LDMConfeccoes.Context;
using LDMConfeccoes.Models;
using LDMConfeccoes.Repositories.Interfaces;

namespace LDMConfeccoes.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
