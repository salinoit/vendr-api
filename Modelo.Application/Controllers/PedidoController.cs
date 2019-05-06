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
        
        public PedidoController(IRepository<PedidoDTO>  usuarioRepository)
        {
            _pedidoRepository = usuarioRepository;
        }


        // GET api/Produto
        [HttpPost]
        [Route("Filter")]
        public IEnumerable<PedidoDTO> Filter([FromBody] Filtros filtro)
        {
            var list = _pedidoRepository.ListAs();

            if (filtro.consumidor>0)
            {
                list = list.Where(p => p.id_consumidor == filtro.consumidor).ToList();
            }

            if (!String.IsNullOrEmpty(filtro.inicio))
            {
                list = list.Where(p => p.data_pedido>= Convert.ToDateTime(filtro.inicio) && p.data_pedido<=Convert.ToDateTime(filtro.fim)).ToList();
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
        public IActionResult Post([FromBody] PedidoDTO usuarioPerfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _pedidoRepository.Insert(usuarioPerfil);
                return Ok("OK");
            }
            catch (Exception e)
            {
                return Ok("Usuário já cadastrado!");
            }
        }
    }

}


