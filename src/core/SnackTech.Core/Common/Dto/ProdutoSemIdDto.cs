
namespace SnackTech.Core.Common.Dto
{
    public class ProdutoSemIdDto
    {
        public int Categoria {get; set;}
        public string Nome {get; set;} = string.Empty;
        public string Descricao{get; set;} = string.Empty;
        public decimal Valor {get; set;}
    }
}