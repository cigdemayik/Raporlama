using System;
using System.Threading.Tasks;
using Raporlama.DataAccess.Abstracts.Interfaces.Generic;
using Raporlama.Entities.Concrete.BaseModel;
namespace Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic
{
    public interface IUnitOfWork
    {
            IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
            void SaveChanges();
            Task SaveChangesAsync();      
    }
}
