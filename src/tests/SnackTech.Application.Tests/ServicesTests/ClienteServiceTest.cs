using SnackTech.Application.Services;
using SnackTech.Domain.Contracts;
using SnackTech.Domain.Guards;
using SnackTech.Domain.Models;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace SnackTech.Application.Tests.ServicesTests;

public class ClienteServiceTest
{
    [Fact]
    public void SaveClienteWithValidData()
    {
        var cliente = new Cliente("Joao", "aaa@teste.com", "12345678909");
        IClienteRepository mockRepo = Mock.Create<IClienteRepository>();
        Mock.Arrange(() => mockRepo.Save(cliente)).OccursOnce();

        var service = new ClienteService(mockRepo);

        service.Save(cliente);

        Mock.Assert(mockRepo);
    }
}
