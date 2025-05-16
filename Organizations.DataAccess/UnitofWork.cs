using Common.StandardInfrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Organizations.DataAccess
{
    public  class UnitOfWork : IUnitOfWork 
    {
        private readonly DbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(DbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public IRepositoryAsync<T> GetRepository<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<IRepositoryAsync<T>>();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            _context?.Dispose();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

