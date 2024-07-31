using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.WebApp.Mvc.Controllers.Admin
{
    public class AdminProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("Admin-Produtos")]
        public async Task<IActionResult> Index()
        {
            var produto = await _produtoAppService.ObterTodos();

            return View(produto);
        }

        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDto()));
        }

        [HttpPost]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto(ProdutoDto produto)
        {
            //ModelState.Remove("Categorias");
            if (!ModelState.IsValid) return View(await PopularCategorias(produto));
            await _produtoAppService.AdicionarProduto(produto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoAppService.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDto produtoViewModel)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            produtoViewModel.QuantidadeEstoque = produto.QuantidadeEstoque;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoViewModel));

            await _produtoAppService.AtualizarProduto(produtoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }

            return View("Index", await _produtoAppService.ObterTodos());
        }

        private async Task<ProdutoDto> PopularCategorias(ProdutoDto produto)
        {
            produto.Categorias = await _produtoAppService.ObterCategorias();
            return produto;
        }
    }
}

