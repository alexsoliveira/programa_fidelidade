using Business.Interfaces;

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
    }
}
