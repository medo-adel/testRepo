using Common.StandardInfrastructure;
using Common.StandardInfrastructure.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Organizations.DataAccess.Repositories.Base
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseModel
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;
        public RepositoryAsync(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        private static Expression<Func<T, bool>> GetPredicate(Expression<Func<T, bool>> predicate = null, bool isOrganization = true)
        {
            ExpressionStarter<T> expr;
            if (predicate == null) expr = PredicateBuilder.New<T>(true); else expr = predicate;
            if (isOrganization) expr = expr.And(q => !q.IsDelete);
            return expr;
        }

        public async Task<T> AddAsync(T entity, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() => DbSet.Add(entity).Entity);
            return await task;
        }
        public async Task AddRangeAsync(IEnumerable<T> entities, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() => DbSet.AddRange(entities));
            await task;
        }

        public async Task<(IEnumerable<T>, int)> GetPagedListAsync(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> predicateUnion = null, bool isDelete = true, bool isOrganization = true, Expression<Func<T, string>> searchItem = null, string[] list = null,bool getCount=true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization: isOrganization));
            if (!sortFromAnotherService)
                query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (sortFromAnotherService && orderBy != null) query = orderBy(query);

            if (include != null) query = include(query).AsSplitQuery();
            var count = 0;
            if (getCount)
                 count = await query.CountAsync();
            var queryData = pagingSortingDto.Limit == 1 ? query : query.GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit ?? 10);
            if (predicateUnion == null) return (await queryData.ToListAsync(), count);
            IQueryable<T> queryUnion = DbSet;
            var unionData = queryUnion.Where(GetPredicate(predicateUnion, isOrganization));
            if (include != null) unionData = include(unionData).AsSplitQuery();
            var result = queryData.Union(unionData);
            return (await result.ToListAsync(), count);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null,
            bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization));
            if (pagingSortingDto != null)
                query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            return await query.ToListAsync();
        }


        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query).AsSplitQuery();
            if (orderBy != null) query = orderBy(query);
            return await query.FirstOrDefaultAsync(GetPredicate(predicate, isOrganization));
        }
        public async Task<T> GetAsync(params object[] id)
        {
            var task = Task.Factory.StartNew(() => DbSet.Find(id));
            return await task;
        }
        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(isOrganization: isOrganization));
            if (include != null) query = include(query).AsSplitQuery();
            return await query.ToListAsync();
        }

        public async Task<bool> IsExistAsync<TDto>(TDto dto, bool isDelete = true, bool isOrganization = true, bool includeCountry = true) => await DbSet.AnyAsync(GetPredicate(Helper.GetPredicateIsExist<T, TDto>(dto, includeCountry), isOrganization));
        public async Task<bool> IsExistAnyAsync(Expression<Func<T, bool>> predicate, Guid? organizationId = null, bool isDelete = true, bool isOrganization = true) => await DbSet.AnyAsync(GetPredicate(predicate, isOrganization));
        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null, bool isDelete = true, bool isOrganization = true) => predicate == null ? await DbSet.CountAsync(GetPredicate(isOrganization: isOrganization)) : await DbSet.CountAsync(GetPredicate(predicate, isOrganization));
        public async Task RemoveAsync(T entity, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() => DbSet.Remove(entity));
            await task;
        }

        public async Task RemovePhysicalAsync(T entity, bool? auditSave, bool? contextSave)
        {
            var task = Task.Factory.StartNew(() => DbSet.Remove(entity));
            await task;
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() => DbSet.RemoveRange(entities));
            await task;
        }
        public async Task UpdateAsync(T entityNew, T entityOld, bool? auditSave = true, bool? contextSave = true)
        {
            //var task = Task.Factory.StartNew(() => DbSet.Update(entityNew));
            //await task;
             DbSet.Update(entityNew);
        }

        public Task UpdateRangeAsync(IEnumerable<T> entityNew, IEnumerable<T> entityOld)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateRangeAsync(IEnumerable<T> entityNew)
        {
            var task = Task.Factory.StartNew(() => Context.UpdateRange(entityNew));
            await task;
        }
        public async Task<IEnumerable<TType>> FindSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization));
            if (pagingSortingDto != null) query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            return await query.Select(select).ToListAsync();
        }

        public async Task<TType> FirstOrDefaultSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization));
            if (pagingSortingDto != null) query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            if (orderBy != null) query = orderBy(query);
            return await query.Select(select).FirstOrDefaultAsync();
        }
        public async Task<(IEnumerable<TType>, int)> GetPagedListSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, bool isDelete = true, bool isOrganization = true, Expression<Func<T, bool>> predicateUnion = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool getCount = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization));
            if (!sortFromAnotherService) query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            var count = await query.CountAsync();
            return pagingSortingDto.Limit == 1 ? (await query.Select(select).ToListAsync(), count) : (await query.GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit ?? 10).Select(select).ToListAsync(), count);
        }

        public (IEnumerable<T>, int) GetPagedList(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> predicateUnion = null, bool isDelete = true, bool isOrganization = true)
        {
            throw new NotImplementedException();
        }
        public TResult ExecuteQuery<TResult>(Func<IQueryable<T>, TResult> queryFunction) => queryFunction(DbSet);
        public IList<TReturn> GetGrouped<TResult, TGroup, TReturn>(
            List<Expression<Func<T, bool>>> predicates,
            PagingSortingDto pagingSortingDto,
            Expression<Func<T, TResult>> firstSelector,
            Func<TResult, TGroup> groupSelector,
            Func<IGrouping<TGroup, TResult>, TReturn> selector,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var entities = DbSet.AsQueryable();
            if (include != null) entities = include(entities).AsSplitQuery();
            return predicates
                .Aggregate(entities, (current, predicate) => current.Where(predicate))
                .Select(firstSelector)
                .OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField)
                .GroupBy(groupSelector).Skip(--pagingSortingDto.Offset * pagingSortingDto.Limit ?? 10).Take(pagingSortingDto.Limit ?? 0)
                .Select(selector)
                .ToList();
        }
        public IList<TReturn> GetGrouped<TResult, TGroup, TReturn>(
                List<Expression<Func<T, bool>>> predicates,
                Expression<Func<T, TResult>> firstSelector,
                Func<TResult, TGroup> groupSelector,
                Func<IGrouping<TGroup, TResult>, TReturn> selector,
                Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                Func<TReturn, bool> expression = null)
        {
            var entities = DbSet.AsQueryable();
            if (include != null) entities = include(entities).AsSplitQuery();
            var qry = predicates
                .Aggregate(entities, (current, predicate) => current.Where(predicate))
                .Select(firstSelector)
                .GroupBy(groupSelector)
                .Select(selector);
            if (expression != null)
            {
                qry = qry.Where(expression);
            }
            return qry.ToList();
        }
        public IQueryable<T> GetAllAsQueryable(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool asSplitQuery = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (include != null)
            {
                query = asSplitQuery? include(query).AsSplitQuery(): include(query).AsSingleQuery();
            }

            if (predicate != null)
            {
                query = query.Where(GetPredicate(predicate,isOrganization: isOrganization));
            }
            return query;
        }
        public async Task<IQueryable<TType>> GetAllWithSelectAsQueryable<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool asSplitQuery = true, bool isOrganization = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (include != null)
            {
                query = asSplitQuery ? include(query).AsSplitQuery() : include(query).AsSingleQuery();
            }
            if (predicate != null)
            {
                query = query.Where(GetPredicate(predicate, isOrganization: isOrganization));
            }
            var selectedQuery = query.Select(select);
            return selectedQuery;
        }


    }


}
