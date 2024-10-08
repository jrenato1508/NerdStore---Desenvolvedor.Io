﻿using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public Guid ClienteId { get; private set; }

        public Guid PeidoId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public string NomeProduto { get; private set; }

        public decimal ValorUnitario { get; private set; }

        public int Quantidade { get; private set; }

        public PedidoItemAdicionadoEvent(Guid clienteId, Guid pedidoId, Guid protutoId, string nomeProduto, decimal valorUnitario, int quantidade)
        {
            
            AggregateId = pedidoId;
            ClienteId = clienteId;
            PeidoId = pedidoId;
            ProdutoId = protutoId;
            NomeProduto = nomeProduto;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }
    }
}
