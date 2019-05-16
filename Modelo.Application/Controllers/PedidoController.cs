
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
    public class PedidoController : Controller
    {
                
        public class Filtros
        {

            public int  consumidor { get; set; }

            public string inicio { get; set; }

            public string fim { get; set; }

            public int status { get; set; }

        }

        private readonly IRepository<PedidoDTO> _pedidoRepository;

        private readonly IRepository<VendedorDto> _vendedorRepository;

        private readonly IRepository<UsuarioDto> _usuarioRepository;

        private readonly IPedidoItemDApper _pedidoItemRepository;

        private readonly IPedidoDapper _pedidoDapper;

        private readonly Vendr.Infra.Data.Context.DBContext _context;

        public PedidoController(IRepository<PedidoDTO>  usuarioRepository,IPedidoDapper pedido_dapper, Vendr.Infra.Data.Context.DBContext context, IPedidoItemDApper pedido_items, IRepository<VendedorDto> vendedor_repo, IRepository<UsuarioDto> usuario_repo)
        {
            _pedidoRepository = usuarioRepository;
            _context = context;
            _pedidoDapper = pedido_dapper;
            _pedidoItemRepository = pedido_items;
            _vendedorRepository = vendedor_repo;
            _usuarioRepository = usuario_repo;
        }


        // GET api/Produto
        [HttpPost]
        [Route("Filter")]
        public IEnumerable<PedidoDTO> Filter([FromBody] Filtros filtro)
        {

            DateTime inicio = Convert.ToDateTime(filtro.inicio + " 00:00:00");
            DateTime fim = Convert.ToDateTime(filtro.fim + " 23:59:59");

            if (filtro.consumidor <= 0) throw new Exception("Deve fornecer o id do consumidor");

            var list = _pedidoDapper.List(filtro.consumidor);

            if (!String.IsNullOrEmpty(filtro.inicio))
            {
                list = list.Where(p => p.data_pedido>= inicio && p.data_pedido<=fim).ToList();
            }

            if (filtro.status > 0)
            {
                list = list.Where(p => p.id_status_pedido == filtro.status).ToList();
            }
            
            return list;
        }

        [HttpGet]
        [Route("All")]
        public IEnumerable<PedidoDTO> All()
        {
            var list = _pedidoRepository.ListAs();
            return list;
        }


        //PUT: api/usuario/5
        [HttpPost]
        public IActionResult Post([FromBody] CartDto cart,[FromQuery] int id_consumidor, [FromQuery] int id_vendedor)
        {

            if (cart.items.Count==0 || id_consumidor==0 || id_vendedor==0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Pedido novo = new Pedido();
                novo.Ativo = true;
                novo.DataCriacao = System.DateTime.Now;
                novo.DataPedido = System.DateTime.Now;
                novo.Desconto = 0;
                novo.FormaPagamento = "1";
                novo.IdConsumidor = id_consumidor;
                novo.IdVendedor = id_vendedor;
                novo.IdStatusPedido = 1;
                novo.ValorFrete = 0;
                novo.ValorPedido = Convert.ToDecimal(cart.total);
                novo.Periodo = 1;

                foreach (CartItemDto x in cart.items)
                {
                    PedidoItem item = new PedidoItem();
                    item.Ativo = true;
                    item.IdProdutoServico = x.produto.IdProdutoServico;
                    item.LastUpdate = 1;
                    item.Quantidade = x.qtd;
                    item.PrecoUnitario = x.produto.PrecoVenda;
                    item.PrecoFinal = (x.produto.PrecoVenda * x.qtd);
                    item.PrecoCusto = x.produto.PrecoVenda;
                    novo.PedidoItem.Add(item);
                }

                _context.Add(novo);

                _context.SaveChanges();

                return Ok(novo.IdPedido);

            }
            catch (Exception e)
            {
                return  BadRequest();
            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Pedido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var p = _pedidoRepository.SelectAs(id);

            var i = _pedidoItemRepository.ListAs(id);

            var v = _vendedorRepository.Select(p.id_vendedor);

            var u = _usuarioRepository.Select(p.id_consumidor);

            var retorno = new
            {
                pedido = p,
                items = i,
                vendedor = v,
                cliente = u
            };
            return Ok(retorno);
        }
    }

}


