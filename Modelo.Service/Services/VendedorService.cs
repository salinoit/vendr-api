using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vendr.Domain.Interfaces;
using Vendr.Domain.Entities;
using Vendr.Infra.Data.Repository;

namespace Vendr.Service.Services
{
    public class VendedorService : IService<Vendedor>, IDisposable
    {

        private readonly IRepositoryAsync<Vendedor> _repository;

        public VendedorService(IRepositoryAsync<Vendedor> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task AddAsync(Vendedor dto)
        {
            _repository.Add(dto);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Vendedor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Vendedor dto)
        {
            _repository.Update(dto);
            await _repository.CommitAsync();

        }
    }
}
