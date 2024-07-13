using SnackTech.Domain.Contracts;
using SnackTech.Domain.Models;

namespace SnackTech.Application.Services;

public class ClienteService
{
    private readonly IClienteRepository clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    public void Save(Cliente cliente)
    {
        clienteRepository.Save(cliente);
    }

    public Cliente Get(string cpf)
    {
        return clienteRepository.Get(cpf);
    }
}
