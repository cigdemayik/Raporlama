using Microsoft.EntityFrameworkCore;
using Raporlama.Entities.Abstracts.Interfaces;
using Raporlama.Entities.Concrete;
using Raporlama.Entities.Concrete.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Raporlama.DataAccess.Abstracts.Interfaces.Generic
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        #region Syncronics
        IQueryable<TEntity> GetAllByFilter(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.NoTracking);
        TEntity GetByFilter(Expression<Func<TEntity, bool>> filter, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.TrackAll);
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        #endregion

        #region Asyncronics
        Task<IQueryable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.NoTracking);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, List<string> includes = null, QueryTrackingBehavior isTracking = QueryTrackingBehavior.TrackAll);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        #endregion

    }
}
