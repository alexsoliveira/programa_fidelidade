using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context) { }
    }
}
