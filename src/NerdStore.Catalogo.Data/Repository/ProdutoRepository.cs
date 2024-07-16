using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Catalogo.Domain.Entitys;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogoContext;

        public ProdutoRepository(CatalogoContext context)
        {
            _catalogoContext = context;
        }

        
        public IUnitOfWork UnitOfWork => _catalogoContext;


        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _catalogoContext.Produtos.AsNoTracking().ToListAsync();
        }
        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _catalogoContext.Produtos.FindAsync(id);
        }
        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _catalogoContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _catalogoContext.Categorias.AsNoTracking().ToListAsync();
        }

       
        public void Adicionar(Produto produto)
        {
            _catalogoContext.Produtos.Add(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _catalogoContext.Categorias.Add(categoria);
        }

        public void Atualizar(Produto produto)
        {
            _catalogoContext.Update(produto);
        }

        public void Atualizar(Categoria categoria)
        {
            _catalogoContext.Update(categoria);
        }

        public void Dispose()
        {
            _catalogoContext?.Dispose();
        }
    }
}
