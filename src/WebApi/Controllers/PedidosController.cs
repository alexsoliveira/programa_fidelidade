using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;        
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository,                                  
                                  IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;            
            _mapper = mapper;
        }

        [HttpPost("listagem-pedidos-status-entrega")]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> ListagemPedidos()
        {
            var pedidos = _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.Buscar(p => p.StatusEntrega == true));

            return Ok(pedidos);
        }
    }
}
