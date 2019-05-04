using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendr.Domain.Interfaces;
using Vendr.Domain.Entities;
using Vendr.Domain.Dto;
using AutoMapper;
using Vendr.Infra.CrossCutting.Extensions;

namespace Vendr.Application.Controllers
{
    [AllowAnonymous]
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IService<ProdutoServico> _ProdutoServicoService;
        private readonly IProdutoDapper _produtoDapperRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IService<ProdutoServico> ProdutoServicoService, IMapper mapper, IProdutoDapper produtoDapperRepository)
        {
            _ProdutoServicoService = ProdutoServicoService;
            _mapper = mapper;
            _produtoDapperRepository = produtoDapperRepository;
        }

        // GET api/Produto
        [HttpGet]
        public IEnumerable<ProdutoDto> Get()
        {
            var list = _ProdutoServicoService.GetAllAsync().Result;
            return _mapper.Map<IEnumerable<ProdutoDto>>(list);
        }

        [HttpGet("paged/{page}/{size}")]
        public IActionResult paged([FromRoute] int page,int size,[FromQuery] string search, [FromQuery] int vendedor, int order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }        

            var pack = _produtoDapperRepository.SelectPagedAs(page, size, search,order,0,vendedor);
            var ret = new
            {
                total = pack.total,
                items = pack.items
            };
            
            return Ok(ret);
        }

        // GET api/Produto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var t = await _ProdutoServicoService.GetByIdAsync(id);
            var tDto = _mapper.Map<ProdutoDto>(t);

            if (t == null)
            {
                return NotFound();
            }
            return Ok(tDto);
        }

        //PUT: api/Produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProdutoServico ProdutoServico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != ProdutoServico.IdProdutoServico)
            {
                return BadRequest();
            }
            try
            {
                 await _ProdutoServicoService.UpdateAsync(ProdutoServico);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var result = await _ProdutoServicoService.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoServico ProdutoServico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ProdutoServicoService.AddAsync(ProdutoServico);
            return CreatedAtAction("Get", new { id = ProdutoServico.IdProdutoServico }, ProdutoServico);
        }

        //DELETE: api/Produto/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ProdutoServicoService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            
            await _ProdutoServicoService.DeleteAsync(id);
            return Ok(result);

        }

    }

}


