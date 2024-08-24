using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRascunhoIniciadoEvent>,
                                      INotificationHandler<PedidoAtualizadoEvent>,
                                      INotificationHandler<PedidoItemAdicionadoEvent>,
                                      INotificationHandler<PedidoProdutoAtualizadoEvent>,
                                      INotificationHandler<PedidoProdutoRemovidoEvent>,
                                      INotificationHandler<VoucherAplicadoPedidoEvent>,
                                      INotificationHandler<PedidoEstoqueRejeitadoEvent>
                                      
    {

        private readonly IMediatorHandler _mediatorHandler;

        public PedidoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;    
        }

        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoProdutoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoProdutoRemovidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(VoucherAplicadoPedidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PedidoEstoqueRejeitadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}


