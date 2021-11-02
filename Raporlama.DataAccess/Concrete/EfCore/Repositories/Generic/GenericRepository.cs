using Microsoft.EntityFrameworkCore;
using Raporlama.DataAccess.Abstracts.Interfaces.Generic;
using Raporlama.DataAccess.Concrete.EFramework.Context;
using Raporlama.Entities.Abstracts.Interfaces;
using Raporlama.Entities.Concrete;
using Raporlama.Entities.Concrete.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Raporlama.DataAccess.Concrete.EfCore.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity:BaseEntity
    {
        private readonly RaporlamaContext _context;

        public GenericRepository(RaporlamaContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            bool value = false;
            try
            {
                _context.Set<TEntity>().Remove(entity);
                value = true;
            }
            catch (Exception ex)
            {

            }
            return value;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            bool value = false;
            try
            {
                await Task.Run(() => _context.Remove(entity));
                value = true;
            }
            catch (Exception ex)
            {

            }
            return value;

        }


        public IQueryable<TEntity> GetAllByFilter(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.NoTracking)
        {
            var operationData = _context.Set<TEntity>().AsTracking(isTracking);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    operationData = includes.Aggregate(operationData, (current, include) => current.Include(include));
                }
            }
            if (filter != null)
            {
                operationData = operationData.Where(filter);
            }
            return operationData;
        }

        public async Task<IQueryable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.NoTracking)
        {
            var operationData = _context.Set<TEntity>().AsTracking(isTracking);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    operationData = includes.Aggregate(operationData, (current, include) => current.Include(include));
                }

            }
            if (filter != null)
            {
                operationData = await Task.Run(() => operationData.Where(filter));
            }
            return operationData;
        }

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> filter, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.TrackAll)
        {
            var operationData = _context.Set<TEntity>().AsTracking(isTracking);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    operationData = includes.Aggregate(operationData, (current, include) => current.Include(include));
                }

            }

            return operationData.FirstOrDefault(filter);
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.TrackAll)
        {
            var operationData = _context.Set<TEntity>().AsTracking(isTracking);
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    operationData = includes.Aggregate(operationData, (current, include) => current.Include(include));
                }

            }

            return await operationData.FirstOrDefaultAsync(filter);
        }

        public bool Update(TEntity entity)
        {
            bool value = false;
            try
            {
                var updatedEntity = _context.Set<TEntity>().Find(entity.Id);
                _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
                value = true;
            }
            catch (Exception)
            {

            }
            return value;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            bool value = false;
            try
            {
                var updatedEntity = await _context.Set<TEntity>().FindAsync(entity.Id);
                await Task.Run(() => _context.Entry(updatedEntity).CurrentValues.SetValues(entity));
                value = true;
            }
            catch (Exception)
            {

            }
            return value;
        }

    }
}
