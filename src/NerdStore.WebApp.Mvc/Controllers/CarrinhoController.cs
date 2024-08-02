using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Vendas.Application.Commands;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(IProdutoAppService produto,IMediatorHandler mediator)
        {
            _produtoAppService = produto;
            _mediatorHandler = mediator;   
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid Id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(Id);
            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { Id });
            }

            
            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(command);

            
            //if (OperacaoValida())
            //{
            //    return RedirectToAction("Index");
            //}


            TempData["Erro"] = "Produto Indisponível";
            //TempData["Erros"] = ObterMensagensErro();

            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { Id });
        }
    }
}
