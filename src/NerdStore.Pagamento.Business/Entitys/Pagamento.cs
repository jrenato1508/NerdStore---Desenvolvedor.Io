﻿using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Pagamentos.Business.Entitys
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public Guid PedidoId { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        // EF. Rel.
        public Transacao Transacao { get; set; }
    }
}
