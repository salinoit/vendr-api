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
        public IActionResult Get([FromBody]CartDto cq)
        {            

            Dictionary<int, CartItemDto> _items = new Dictionary<int, CartItemDto>();            

            foreach (CartItemDto c in cq.items)
            {

                CartItemDto _i = null;

                _items.TryGetValue(c.produto.IdProdutoServico, out  _i);

                if (_i!=null)
                {
                    _i.qtd += c.qtd;
                }
                else
                {
                    _items.Add(c.produto.IdProdutoServico, c);
                }                
            }

            CartDto cart = new CartDto();

            cart.total = 0;

            var items_agora = from c in _items select (c.Value);

            
            foreach (CartItemDto c in items_agora)
            {
                var p = _produtoDapperRepository.SelectAs(c.produto.IdProdutoServico);

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
            
            return Ok(cart);

        }
        
    }

}


