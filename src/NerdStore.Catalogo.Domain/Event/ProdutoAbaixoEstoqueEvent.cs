using NerdStore.Core.Messages.CommonMessages.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Event
{
    public class ProdutoAbaixoEstoqueEvent : DomaninEvent
    {
        public int QuantidadeRestante { get; private set; }
        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
