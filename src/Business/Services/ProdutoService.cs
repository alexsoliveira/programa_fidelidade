using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;        

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;            
        }        

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public Task<List<Produto>> ProdutosDisponivelResgate(Expression<Func<Produto, bool>> disponivel)
        {
            return _produtoRepository.ProdutosDisponivelResgate(disponivel);
        }
    }
}
