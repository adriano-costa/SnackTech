using Microsoft.AspNetCore.Mvc;
using SnackTech.Common.Dto.Api;
using SnackTech.Core.Interfaces;
using SnackTech.Driver.API.CustomResponses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace SnackTech.Driver.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController(ILogger<PedidosController> logger, IPedidoController pedidoDomainController) : CustomBaseController(logger)
    {
        /// <summary>
        /// Inicia um novo pedido a partir do CPF de um cliente previamente cadastrado no banco. 
        /// Informe null para iniciar um novo pedido do cliente padrão.
        /// </summary>
        /// <remarks>
        /// Cria um novo pedido para o cliente especificado pelo CPF.
        /// </remarks>
        /// <param name="pedidoIniciado">Objeto contendo o CPF do cliente para iniciar o pedido.</param>
        /// <returns>Um <see cref="IActionResult"/> contendo o identificador do novo pedido ou um erro correspondente.</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<Guid>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("")]
        [SwaggerOperation(Summary = "Inicia um novo pedido a partir do CPF de um cliente previamente cadastrado no banco. Informe null para iniciar um novo pedido do cliente padrão")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o identificador do novo pedido", typeof(Guid))]
        public async Task<IActionResult> IniciarPedido([FromBody] IniciarPedidoDto pedidoIniciado)
            => await ExecucaoPadrao("Pedidos.IniciarPedido", pedidoDomainController.IniciarPedido(pedidoIniciado.Cpf));

        /// <summary>
        /// Atualiza o pedido (itens anexos) que ainda não esteja no status aguardando pagamento.
        /// </summary>
        /// <param name="atualizacaoPedido">Os dados de atualização do pedido.</param>
        /// <returns>Um <see cref="IActionResult"/> indicando o sucesso ou falha da operação.</returns>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("")]
        [SwaggerOperation(Summary = "Atualiza o pedido (itens anexos) que ainda não esteja no status aguardando pagamento")]
        public async Task<IActionResult> AtualizarPedido([FromBody] PedidoAtualizacaoDto atualizacaoPedido)
            => await ExecucaoPadrao("Pedidos.AtualizarPedido", pedidoDomainController.AtualizarPedido(atualizacaoPedido));

        /// <summary>
        /// Finaliza o pedido com o identificador informado e o coloca na situação de aguardando pagamento.
        /// </summary>
        /// <param name="identificacao">O guid do pedido a ser finalizado.</param>
        /// <returns>Um <see cref="IActionResult"/> indicando o sucesso ou falha da operação.</returns>
        [HttpPatch]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("finalizar-para-pagamento/{identificacao:guid}")]
        [SwaggerOperation(Summary = "Finaliza o pedido com o identificador informado e o coloca na situação de aguardando pagamento")]
        public async Task<IActionResult> FinalizarPedidoParaPagamento([FromRoute] string identificacao)
            => await ExecucaoPadrao("Pedidos.FinalizarPedidoParaPagamento", pedidoDomainController.FinalizarPedidoParaPagamento(identificacao));

        /// <summary>
        /// Retorna a lista de pedidos com status aguardando pagamento.
        /// </summary>
        /// <returns>Um <see cref="IActionResult"/> contendo a lista de pedidos aguardando pagamento ou um erro correspondente.</returns>
        [HttpGet]
        [ProducesResponseType<IEnumerable<PedidoRetornoDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("aguardando-pagamento")]
        [SwaggerOperation(Summary = "Retorna a lista de pedidos com status aguardando pagamento")]
        public async Task<IActionResult> ListarPedidosParaPagamento()
            => await ExecucaoPadrao("Pedidos.ListarPedidosParaPagamento", pedidoDomainController.ListarPedidosParaPagamento());

        /// <summary>
        /// Retorna o pedido com o identificador informado.
        /// </summary>
        /// <param name="identificacao">O guid do pedido a ser pesquisado.</param>
        /// <returns>Um <see cref="IActionResult"/> contendo o pedido encontrado ou um erro correspondente.</returns>
        [HttpGet]
        [ProducesResponseType<PedidoRetornoDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("{identificacao:guid}")]
        [SwaggerOperation(Summary = "Retorna o pedido com o identificador informado")]
        public async Task<IActionResult> BuscarPorIdenticacao([FromRoute] string identificacao)
            => await ExecucaoPadrao("Pedidos.ListarPedidosParaPagamento", pedidoDomainController.BuscarPorIdenticacao(identificacao));

        /// <summary>
        /// Retorna o pedido mais recente do cliente com CPF informado. Não é permitida a consulta do último pedido do cliente padrão.
        /// </summary>
        /// <param name="cpfCliente">O CPF do cliente para buscar o último pedido.</param>
        /// <returns>Um <see cref="IActionResult"/> contendo o último pedido do cliente ou um erro correspondente.</returns>
        [HttpGet]
        [ProducesResponseType<PedidoRetornoDto>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("ultimo-pedido-cliente/{cpfCliente}")]
        [SwaggerOperation(Summary = "Retorna o pedido mais recente do cliente com CPF informado. Não é permitida a consulta do último pedido do cliente padrão")]
        public async Task<IActionResult> BuscarUltimoPedidoCliente([FromRoute] string cpfCliente)
            => await ExecucaoPadrao("Pedidos.ListarPedidosParaPagamento", pedidoDomainController.BuscarUltimoPedidoCliente(cpfCliente));

        /// <summary>
        /// Retorna a lista de pedidos com status Pronto, em Preparação e Recebido
        /// </summary>
        /// <returns>Um <see cref="IActionResult"/> contendo a lista de pedidos.</returns>
        [HttpGet]
        [ProducesResponseType<IEnumerable<PedidoRetornoDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [Route("ativos")]
        [SwaggerOperation(Summary = "Retorna a lista de pedidos com status Pronto, em Preparação e Recebido")]
        public async Task<IActionResult> ListarPedidosAtivos()
            => await ExecucaoPadrao("Pedidos.ListarPedidosAtivos", pedidoDomainController.ListarPedidosAtivos());
    }
}