using LDMConfeccoes.Models;

namespace LDMConfeccoes.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
