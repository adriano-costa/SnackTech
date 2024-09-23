using SnackTech.Domain.Enums;
using SnackTech.Domain.Guards;

namespace SnackTech.Domain.Entities
{
    public class Produto
    {
        public Guid Id {get; private set;}
        public CategoriaProduto Categoria {get; private set;}
        public string Nome {get; private set;}
        public string Descricao {get; private set;}
        public decimal Valor {get; private set;}

        public Produto(CategoriaProduto categoria, string nome, string descricao, decimal valor)
            :this(Guid.NewGuid(), categoria, nome, descricao, valor)
        {}

        public Produto(Guid id, CategoriaProduto categoriaProduto, string nome, string descricao, decimal valor)
        {
            Nome = string.Empty;
            Descricao = string.Empty;
            PreencherDados(categoriaProduto,nome,descricao,valor);
            Id = id;
        }

        protected Produto() { }

        public void AtualizarDadosProduto(CategoriaProduto categoria, string nome, string descricao, decimal valor){
            PreencherDados(categoria,nome,descricao,valor);
        }

        private void PreencherDados(CategoriaProduto categoria, string nome, string descricao, decimal valor){
            CustomGuards.AgainstStringNullOrWhiteSpace(nome, nameof(nome));
            CustomGuards.AgainstStringNullOrEmpty(descricao, nameof(descricao));
            CustomGuards.AgainstNegativeOrZeroValue(valor, nameof(valor));

            Categoria = categoria;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }
        
        public static implicit operator DTOs.Driven.ProdutoDto(Produto produto)
        {
            return new DTOs.Driven.ProdutoDto
            {
                Id = produto.Id,
                Categoria = produto.Categoria,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor
            };
        }

        public static implicit operator Produto(DTOs.Driven.ProdutoDto produtoDto)
        {
            return new Produto {
                Id = produtoDto.Id,
                Categoria = produtoDto.Categoria,
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Valor = produtoDto.Valor
            };
        }
    }
}