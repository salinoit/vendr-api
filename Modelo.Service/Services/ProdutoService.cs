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
    public class ProdutoService : IService<ProdutoServico>, IDisposable
    {

        private readonly IRepositoryAsync<ProdutoServico> _repository;

        public ProdutoService(IRepositoryAsync<ProdutoServico> repository)
        {
            _repository = repository;            
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task AddAsync(ProdutoServico dto)
        {
            _repository.Add(dto);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutoServico>> GetAllAsync()
        {
            return await _repository.GetAllAsync(limit:500,filter:o=>o.Visivel==true && o.Ativo==true);
        }

        public async Task<ProdutoServico> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ProdutoServico dto)
        {
            _repository.Update(dto);
            await _repository.CommitAsync();

        }
    }
}
