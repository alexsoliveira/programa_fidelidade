using System;
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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost("listagem-produtos-disponivel-para-resgate")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> ProdutosDisponivelResgate()
        {
            var produtos =  _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoService.ProdutosDisponivelResgate(p => p.Disponivel == true));
            return Ok(produtos);
        }

        [HttpPost("resgate-produtos")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> ResgateProdutos(Guid idProduto)
        {
            var produtos = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterPorId(idProduto));

            return Ok(produtos);
        }

    }
}
