using SnackTech.Domain.Models;

namespace SnackTech.Domain.Contracts;

public interface IClienteRepository
{
    public void Save(Cliente cliente);
    public Cliente Get(string cpf);
}
