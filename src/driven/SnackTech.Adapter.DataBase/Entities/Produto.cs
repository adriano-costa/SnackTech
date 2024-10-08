
using SnackTech.Domain.Enums;

namespace SnackTech.Adapter.DataBase.Entities
{
    public class Produto
    {
        public Guid Id {get; set;}
        public CategoriaProduto Categoria {get; set;}
        public string Nome {get; set;}
        public string Descricao {get; set;}
        public decimal Valor {get; set;}
    }
}