using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task<List<Produto>> ProdutosDisponivelResgate(Expression<Func<Produto, bool>> disponivel);
    }
}
