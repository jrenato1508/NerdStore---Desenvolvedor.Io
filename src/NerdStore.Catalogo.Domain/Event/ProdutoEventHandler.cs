using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Event
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        //private readonly IEstoqueService _estoqueService;

        public ProdutoEventHandler( IProdutoRepository produtoRepository
                                    /*IEstoqueService estoqueService*/)
        {
            _produtoRepository = produtoRepository;
            //_estoqueService = estoqueService;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent message, CancellationToken cancellationToken)
        {
            var result = await _produtoRepository.ObterPorId(message.AggregateId);

            // Obetemos o produto agora podemos enviar um e-mail para notificar o vendedor e etc....
        }
    }
}

