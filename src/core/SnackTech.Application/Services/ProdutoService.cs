using SnackTech.Domain.Contracts;
using SnackTech.Domain.Enums;
using SnackTech.Domain.Models;

namespace SnackTech.Application.Services;

public class ProdutoService
{
    private readonly IProdutoRepository produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        this.produtoRepository = produtoRepository;
    }

    public void Save(Produto produto)
    {
        produtoRepository.Save(produto);
    }

    public Produto Get(Guid id)
    {
        return produtoRepository.Get(id);
    }

    public void Delete(Guid id)
    {
        produtoRepository.Delete(id);
    }

    public IEnumerable<Produto> GetByCategoria(CategoriaProduto categoriaProduto)
    {
        return produtoRepository.GetByCategoria(categoriaProduto);
    }
}
