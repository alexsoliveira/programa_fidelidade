using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public async Task<List<Produto>> ProdutosDisponivelResgate(Expression<Func<Produto, bool>> disponivel)
        {
            return await Db.Produtos.AsNoTracking().Where(disponivel).ToListAsync();
        }
    }
}
