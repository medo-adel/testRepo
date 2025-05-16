using Common.StandardInfrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace Organizations.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<T> GetRepository<T>() where T : class;
        Task<int> SaveChangesAsync(); 
    }
}
