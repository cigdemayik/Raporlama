using Microsoft.Extensions.DependencyInjection;
using Raporlama.Business.Abstracts.Interfaces;
using Raporlama.Business.Concrete;
using Raporlama.DataAccess;
using Raporlama.DataAccess.Abstracts.Interfaces;
using Raporlama.DataAccess.Abstracts.Interfaces.Generic;
using Raporlama.DataAccess.Concrete.EfCore.Repositories.Generic;
using Raporlama.DataAccess.Concrete.EFCore.Repositories.Generic;
using Raporlama.DataAccess.Concrete.EFramework.Context;
using Raporlama.Helpers.Abstracts;
using Raporlama.Helpers.ServiceHelpers.Concrete;

namespace Raporlama.Business.DependencyResolver
{
    public static class RaporlamaIOC
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<RaporlamaContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Services

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IReportTypeService, ReportTypeManager>();
            services.AddScoped<ICompanyService, CompanyManager>();

            #endregion

            #region Helpers

            services.AddScoped<IServiceResponseHelper, ServiceResponseHelper>();

            #endregion
        }
    }
}
