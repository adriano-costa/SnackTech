using SnackTech.Common.Dto;
using SnackTech.Common.Interfaces.DataSources;
using SnackTech.Core.Gateways;
using SnackTech.Core.Interfaces;
using SnackTech.Core.UseCases;

namespace SnackTech.Core.Controllers;

public class PedidoController(IPedidoDataSource pedidoDataSource, IClienteDataSource clienteDataSource) : IPedidoController
{
    public async Task<ResultadoOperacao<Guid>> IniciarPedido(string? cpfCliente)
    {
        var pedidoGateway = new PedidoGateway(pedidoDataSource);
        var clienteGateway = new ClienteGateway(clienteDataSource);

        var identificacaoPedido = await PedidoUseCase.IniciarPedido(cpfCliente, pedidoGateway, clienteGateway);

        return identificacaoPedido;
    }

    public async Task<ResultadoOperacao<PedidoDto>> BuscarPorIdenticacao(string identificacao)
    {
        var pedidoGateway = new PedidoGateway(pedidoDataSource);
        var pedido = await PedidoUseCase.BuscarPorIdenticacao(identificacao, pedidoGateway);

        return pedido;
    }

    public async Task<ResultadoOperacao<PedidoDto>> BuscarUltimoPedidoCliente(string cpf)
    {
        var pedidoGateway = new PedidoGateway(pedidoDataSource);
        var clienteGateway = new ClienteGateway(clienteDataSource);

        var pedido = await PedidoUseCase.BuscarUltimoPedidoCliente(cpf, pedidoGateway, clienteGateway);

        return pedido;
    }

    public async Task<ResultadoOperacao<List<PedidoDto>>> ListarPedidosParaPagamento()
    {
        var pedidoGateway = new PedidoGateway(pedidoDataSource);

        var pedidos = await PedidoUseCase.ListarPedidosParaPagamento(pedidoGateway);

        return pedidos;
    }

    public async Task<ResultadoOperacao> FinalizarPedidoParaPagamento(string identificacao)
    {
        var pedidoGateway = new PedidoGateway(pedidoDataSource);

        var resultado = await PedidoUseCase.FinalizarPedidoParaPagamento(identificacao, pedidoGateway);

        return resultado;
    }
}
