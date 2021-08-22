using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }
    }
}
