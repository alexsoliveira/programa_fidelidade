using Business.Interfaces;

namespace Business.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public void Dispose()
        {
            _pedidoRepository?.Dispose();
        }
    }
}
