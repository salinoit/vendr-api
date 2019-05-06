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
    public class PedidoItemController : Controller
    {
        
        private readonly IPedidoItemDApper _repository;

        private readonly IRepository<PedidoItemDTO> _repository2;

        public PedidoItemController(IPedidoItemDApper repository, IRepository<PedidoItemDTO> repository2)
        {
            _repository = repository;
            _repository2 = repository2;

        }


        // GET api/Produto
        [HttpGet("{id}")]
        public IEnumerable<PedidoItemDTO> Get([FromRoute] int id)
        {
            var list = _repository.ListAs(id);
            return list;
        }
       

        //PUT: api/usuario/5
        [HttpPost]
        public IActionResult Post([FromBody] PedidoItemDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository2.Insert(item);
                return Ok("OK");
            }
            catch (Exception e)
            {
                return Ok("Item insrido!");
            }
        }
    }

}


