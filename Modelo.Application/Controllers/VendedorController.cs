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
using Vendr.Infra.CrossCutting.Extensions;

namespace Vendr.Application.Controllers
{
    [AllowAnonymous]
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class VendedorController : Controller
    {
        private readonly IService<Vendedor> _vendedorService;

        private readonly IRepository<VendedorDto> _vendedorDapper;

        public VendedorController(IService<Vendedor> vendedorRepository, IRepository<VendedorDto> vendedorDapper)
        {
            _vendedorService = vendedorRepository;
            _vendedorDapper = vendedorDapper;
        }

        // GET api/vendedor
        [HttpGet]
        public IEnumerable<VendedorDto> Get()
        {
            return _vendedorDapper.ListAs();
        }

        // GET api/vendedor/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var t = _vendedorDapper.SelectAs(id);            

            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }

        // GET api/vendedor/sample@sample.com
        //[HttpGet("{email}")]
        //public async Task<IActionResult> Get([FromRoute] string email)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var list = await _vendedorService.GetAllAsync();
        //    var t = list.FirstOrDefault();
        //    if (t == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(t);
        //}


        //PUT: api/vendedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vendedor.IdUsuario)
            {
                return BadRequest();
            }
            try
            {
                 await _vendedorService.UpdateAsync(vendedor);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var result = await _vendedorService.GetByIdAsync(id);
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

        //POST: api/vendedor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _vendedorService.AddAsync(vendedor);
            return CreatedAtAction("Get", new { id = vendedor.IdVendedor }, vendedor);
        }

        //DELETE: api/vendedor/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _vendedorService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            
            await _vendedorService.DeleteAsync(id);
            return Ok(result);

        }

    }

}


