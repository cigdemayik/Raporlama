using Raporlama.DataAccess.Abstracts.Interfaces;
using Raporlama.DataAccess.Abstracts.Interfaces.Generic;
using Raporlama.DataAccess.Concrete.EfCore.Repositories.Generic;
using Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic;
using Raporlama.DataAccess.Concrete.EFramework.Context;
using Raporlama.Entities.Concrete;
using Raporlama.Entities.Concrete.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raporlama.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RaporlamaContext _context;

        public UnitOfWork(RaporlamaContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    
    }
}
