using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context) { }
    }
}
