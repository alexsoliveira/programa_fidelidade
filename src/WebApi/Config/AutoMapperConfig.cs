using AutoMapper;
using Business.Models;
using WebApi.DTOs;

namespace WebApi.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {                        
            CreateMap<ProdutoDTO, Produto>();            
        }
    }
}
