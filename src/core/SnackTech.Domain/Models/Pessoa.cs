using SnackTech.Domain.Guards;

namespace SnackTech.Domain.Models
{
    public class Pessoa
    {
        public Guid Id {get; protected set;}
        public string Nome {get; protected set;}

        public Pessoa(Guid id, string nome){
            CustomGuards.AgainstStringNullOrWhiteSpace(nome, nameof(nome));

            Id = id;
            Nome = nome;
        }

        protected Pessoa() { }
    }
}