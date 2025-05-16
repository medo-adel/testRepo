using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Common.StandardInfrastructure.Repository
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetAsync(params object[] id);
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true);
        Task<(IEnumerable<T>, int)> GetPagedListAsync(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> predicateUnion = null, bool isDelete = true, bool isOrganization = true, Expression<Func<T, string>> searchItem = null, string[] list = null, bool getCount = true);

        (IEnumerable<T>, int) GetPagedList(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false,
            bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> predicateUnion = null, bool isDelete = true, bool isOrganization = true);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isDelete = true, bool isOrganization = true);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isDelete = true, bool isOrganization = true);

        Task<bool> IsExistAsync<TDto>(TDto dto, bool isDelete = true, bool isOrganization = true, bool includeCountry = true);
        Task<bool> IsExistAnyAsync(Expression<Func<T, bool>> predicate, Guid? organizationId = null, bool isDelete = true, bool isOrganization = true);
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null, bool isDelete = true, bool isOrganization = true);
        Task<IEnumerable<TType>> FindSelectAsync<TType>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TType>> select, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            PagingSortingDto pagingSortingDto = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true) where TType : class;
        Task<TType> FirstOrDefaultSelectAsync<TType>(Expression<Func<T, bool>> predicate,
             Expression<Func<T, TType>> select, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
             PagingSortingDto pagingSortingDto = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where TType : class;
        Task<(IEnumerable<TType>, int)> GetPagedListSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, bool isDelete = true, bool isOrganization = true, Expression<Func<T, bool>> predicateUnion = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool getCount = true) where TType : class;

        TResult ExecuteQuery<TResult>(Func<IQueryable<T>, TResult> queryFunction);

        IList<TReturn> GetGrouped<TResult, TGroup, TReturn>(
            List<Expression<Func<T, bool>>> predicates,
            PagingSortingDto pagingSortingDto,
            Expression<Func<T, TResult>> firstSelector,
            Func<TResult, TGroup> groupSelector,
            Func<IGrouping<TGroup, TResult>, TReturn> selector,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IList<TReturn> GetGrouped<TResult, TGroup, TReturn>(
                List<Expression<Func<T, bool>>> predicates,
                Expression<Func<T, TResult>> firstSelector,
                Func<TResult, TGroup> groupSelector,
                Func<IGrouping<TGroup, TResult>, TReturn> selector,
                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
                Func<TReturn, bool> expression = null);
        Task<T> AddAsync(T entity, bool? auditSave = true, bool? contextSave = true);
        Task AddRangeAsync(IEnumerable<T> entities, bool? auditSave = true, bool? contextSave = true);
        Task RemoveAsync(T entity, bool? auditSave = true, bool? contextSave = true);
        Task RemovePhysicalAsync(T entity, bool? auditSave = true, bool? contextSave = true);
        Task RemoveRangeAsync(IEnumerable<T> entities, bool? auditSave = true, bool? contextSave = true);
        Task UpdateAsync(T entityNew, T entityOld, bool? auditSave = true, bool? contextSave = true);
        Task UpdateRangeAsync(IEnumerable<T> entityNew, IEnumerable<T> entityOld);
        Task UpdateRangeAsync(IEnumerable<T> entityNew);

        IQueryable<T> GetAllAsQueryable(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool asSplitQuery = true, bool isOrganization = true);
        Task<IQueryable<TType>> GetAllWithSelectAsQueryable<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool asSplitQuery = true, bool isOrganization = true) where TType : class;
    }
}
