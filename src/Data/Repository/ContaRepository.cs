using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(AppDbContext context) : base(context) { }
    }
}
