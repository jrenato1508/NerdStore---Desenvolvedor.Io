using NerdStore.Core.Data;
using NerdStore.Pagamentos.Business.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Pagamentos.Business.Interface
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void Adicionar(Pagamento pagamento);

        void AdicionarTransacao(Transacao transacao);
    }
}
