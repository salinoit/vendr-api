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
    public class UsuarioController : Controller
    {
        
        private readonly IRepository<UsuarioDto> _usuarioRepository;
        
        public UsuarioController(IRepository<UsuarioDto>  usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

       
        //PUT: api/usuario/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UsuarioDto usuarioPerfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != usuarioPerfil.id_usuario)
            {
                return BadRequest();
            }
            try
            {
                _usuarioRepository.Update(usuarioPerfil);

                return Ok(usuarioPerfil);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return NoContent();
            }            
        }
    }

}


