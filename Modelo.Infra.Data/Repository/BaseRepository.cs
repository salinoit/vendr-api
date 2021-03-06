﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendr.Infra.Data.Context;
using Vendr.Domain.Interfaces;
using Vendr.Domain.Entities;
using Vendr.Infra.CrossCutting.Extensions;

namespace Vendr.Infra.Data.Repository
{
    public class BaseRepository<TEntity> :  IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {        
        private DBContext _context;

        public BaseRepository(DBContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? limit=null)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            includes?.ToList().ForEach(navigation => query = query.Include(navigation));
            if (limit != null)
            {
                if (limit > 0)
                {
                    return query.Take((int)limit);
                }
                else
                {
                    throw new Exception("limite de valor deve ser positivo.");
                }
            }
            else
            {
                return query;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, string[] includes = null, int? limit = null)
        {
            var query = GetQueryable(filter, includes, limit);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);            
        }

        public void AddRange(IEnumerable<TEntity> entity)
        {
            _context.AddRange(entity);            
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            Update(entity);
        }

        public void Merge(TEntity persisted, TEntity current)
        {
            _context.Entry(persisted).CurrentValues.SetValues(current);                        
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool status)
        {
            if (!status) return;
            _context.Dispose();
        }       
    }
}
