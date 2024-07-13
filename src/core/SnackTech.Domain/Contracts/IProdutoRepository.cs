using SnackTech.Domain.Enums;
using SnackTech.Domain.Models;

namespace SnackTech.Domain.Contracts;

public interface IProdutoRepository
{
    public void Save(Produto produto);
    public Produto Get(Guid id);
    public void Delete(Guid id);
    public IEnumerable<Produto> GetByCategoria(CategoriaProduto categoriaProduto);
}
