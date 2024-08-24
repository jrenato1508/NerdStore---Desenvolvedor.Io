using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;


namespace NerdStore.Catalogo.Domain.Event
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>,
                                       INotificationHandler<PedidoIniciadoEvent>
                                       //INotificationHandler<PedidoProcessamentoCanceladoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventHandler( IProdutoRepository produtoRepository,
                                    IEstoqueService estoqueService,
                                    IMediatorHandler mediator)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediator;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent message, CancellationToken cancellationToken)
        {
            var result = await _produtoRepository.ObterPorId(message.AggregateId);

            // Obetemos o produto agora podemos enviar um e-mail para notificar o vendedor e etc....
        }


        
        public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);
            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
            }
        }
    }
}

