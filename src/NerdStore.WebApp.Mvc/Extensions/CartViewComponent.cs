using Microsoft.AspNetCore.Mvc;
using NerdStore.Vendas.Application.Queries;

namespace NerdStore.WebApp.Mvc.Extensions
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IPedidoQueries _pedidoQueries;
                        
        protected Guid ClienteId = Guid.Parse("330daf4d-8b9d-4a74-935c-94cee29128a5");

        public CartViewComponent(IPedidoQueries pedidoQueries)
        {
            _pedidoQueries = pedidoQueries;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carrinho = await _pedidoQueries.ObterCarrinhoCliente(ClienteId);
            var itens = carrinho?.Items.Count ?? 0;

            return View(itens);
        }
    }
}
