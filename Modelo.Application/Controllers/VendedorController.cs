using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendr.Domain.Interfaces;
using Vendr.Domain.Entities;

namespace Vendr.Application.Controllers
{
    [AllowAnonymous]
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class VendedorController : Controller
    {

        private readonly IRepositoryAsync<Vendedor> _vendedorRepository;

        public VendedorController(IRepositoryAsync<Vendedor> vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;            
        }

        // GET Api/vendedor
        [HttpGet]
        public IEnumerable<Vendedor> Get()
        {                       
            return _vendedorRepository.GetAllAsync(includes:new string[] {"Consumidor"}).Result.Where(p=>p.Consumidor.Count>0).Take(10);
        }

        
        [HttpGet("{email}")]
        public IEnumerable<object> Get(string email)
        {
            List<object> c = new List<object>()
               {
                   new { idVendedor=1,nome="teste" },
                   new { idVendedor=2,nome="teste" },
                   new { idVendedor=3,nome="teste" }
               };

            return c;
        }
        //return _vendedorRepository.GetAllAsync(includes: new string[] { "Consumidor" }).Result.Where(p => p.Consumidor.Count > 0).Take(10);

    // GET Api/vendedor/5
    [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _vendedorRepository.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        //PUT:api/vendedor/5
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
                 _vendedorRepository.Update(vendedor);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var result = await _vendedorRepository.GetByIdAsync(id);
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
            _vendedorRepository.Add(vendedor);
            return CreatedAtAction("Get", new { id = vendedor.IdVendedor }, vendedor);
        }


        //DEÇETE: api/vendedor/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _vendedorRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _vendedorRepository.DeleteAsync(id);

            return Ok(result);
        }
    }
}
