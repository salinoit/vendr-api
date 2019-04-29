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
    public class CartController : Controller
    {
        private readonly IService<ProdutoServico> _ProdutoServicoService;
        private readonly IRepository<ProdutoDto> _produtoDapperRepository;
        private readonly IMapper _mapper;

        public CartController(IService<ProdutoServico> ProdutoServicoService, IRepository<ProdutoDto> produtoDapperRepository, IMapper mapper)
        {
            _ProdutoServicoService = ProdutoServicoService;
            _mapper = mapper;
            _produtoDapperRepository = produtoDapperRepository;
        }

        // GET api/cart
        [HttpPost]
        public IActionResult Get([FromBody]CartQueryDto cq)
        {
            bool have = false;

            CartDto cart = new CartDto();
            foreach (CartQueryItemDto c in cq.existentes)
            {
                if (cq.novo!=null)
                {
                    if (c.id == cq.novo.id)
                    {
                        have = true;
                        c.qtd += cq.novo.qtd;
                    }
                }
            }
            if (cq.novo != null)
            {
                if (have == false)
                {
                    cq.existentes.Add(cq.novo);
                }
            }

            cart.total = 0;

            foreach (CartQueryItemDto c in cq.existentes)
            {

                var p = _produtoDapperRepository.SelectAs(c.id);                
                if (p!=null)
                {
                    CartItemDto i = new CartItemDto();
                    i.produto = p;
                    i.qtd = c.qtd;                    
                    cart.total += (i.qtd * Convert.ToDouble(i.produto.PrecoVenda));
                    cart.items.Add(i);
                }                
            }

            cart.total_fmt = string.Format("{0:c2}", cart.total);

            var ret = new
            {
                total = cart.total,
                total_fmt = cart.total_fmt,
                items = cart.items.ToArray()
            };

            return Ok(ret);
        }
        
    }

}


