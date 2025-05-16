using Audit.Core;
using Common.StandardInfrastructure.Audit;
using Common.StandardInfrastructure.Interface;
using DocumentFormat.OpenXml.Drawing.Charts;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
// ReSharper disable PossibleMultipleEnumeration

namespace Common.StandardInfrastructure.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class, IBaseEntityModel
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;
        private readonly ISessionStorage _sessionStorage;
        public readonly AuditTransaction AuditTransaction;
        public RepositoryAsync(DbContext context)
        {
            Context = context;
            _sessionStorage = new SessionStorage();
            AuditTransaction = new AuditTransaction();
            DbSet = Context.Set<T>();
        }

        private Expression<Func<T, bool>> GetPredicate(Expression<Func<T, bool>> predicate = null, bool isDelete = true, bool isOrganization = true)
        {
            ExpressionStarter<T> expr;
            if (predicate == null) expr = PredicateBuilder.New<T>(true); else expr = predicate;
            if (isDelete) expr = expr.And(q => !q.IsDelete);
            if (isOrganization) expr = expr.And(q => q.OrganizationId == _sessionStorage.OrganizationId || q.OrganizationId == null);
            return expr;
        }


        public async Task<(IEnumerable<T>, int)> GetPagedListAsync(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> predicateUnion = null, bool isDelete = true, bool isOrganization = true, Expression<Func<T, string>> searchItem = null, string[] list = null,bool getCount=true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization: isOrganization));
            if (searchItem != null && list != null)
            {
                query = query.Search(stringProperties: searchItem).Containing(list);
            }
            if (!sortFromAnotherService && pagingSortingDto.SortField == "id")
                query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField, orderBy);
            else if (pagingSortingDto.SortField != "")
                query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            var count = 0;
            if(getCount) 
             count = await query.CountAsync();
            var queryData = pagingSortingDto.Limit == 1 ? query : query.GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit ?? 10);
            if (predicateUnion == null) return (await queryData.ToListAsync(), count);
            IQueryable<T> queryUnion = DbSet;
            var unionData = queryUnion.Where(GetPredicate(predicateUnion, isDelete, isOrganization));
            if (include != null) unionData = include(unionData).AsSplitQuery();
            var result = queryData.Union(unionData);
            return (await result.ToListAsync(), count);
        }
        public (IEnumerable<T>, int) GetPagedList(Expression<Func<T, bool>> predicate, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> predicateUnion = null, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> dbsetQuery = DbSet;
            if (include != null) dbsetQuery = include(dbsetQuery).AsSplitQuery();
            if (dbsetQuery != null)
            {
                var query = dbsetQuery.AsEnumerable();
                query = query.Where(GetPredicate(predicate, isOrganization: isOrganization).Compile());
                if (!sortFromAnotherService)
                    query = query.AsQueryable().OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField, orderBy);
                if (sortFromAnotherService && orderBy != null) query = orderBy(query.AsQueryable());

                var count = query.Count();
                var queryData = pagingSortingDto.Limit == 1 ? query : query.AsQueryable().GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit ?? 10);
                if (predicateUnion == null) return (queryData.ToList(), count);
                IQueryable<T> queryUnion = DbSet;
                var unionData = queryUnion.Where(GetPredicate(predicateUnion, isDelete, isOrganization));
                if (include != null) unionData = include(unionData).AsSplitQuery();
                var result = queryData.Union(unionData);
                return (result.ToList(), count);
            }

            return (null, 0);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null,
            bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isDelete, isOrganization));
            if (pagingSortingDto != null)
                query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            if (orderBy != null) query = orderBy(query);
            return await query.ToListAsync();
        }


        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            if (include != null) query = include(query).AsSplitQuery();
            if (orderBy != null) query = orderBy(query);
            return await query.FirstOrDefaultAsync(GetPredicate(predicate, isDelete, isOrganization));
        }
        public async Task<T> GetAsync(params object[] id)
        {
            IQueryable<T> query = DbSet;
            return await query.FirstOrDefaultAsync(q => q.Id == new Guid(id[0].ToString()));
        }
        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(isDelete: isDelete, isOrganization: isOrganization));
            if (include != null) query = include(query).AsSplitQuery();
            return await query.ToListAsync();
        }

        public async Task<bool> IsExistAsync<TDto>(TDto dto, bool isDelete = true, bool isOrganization = true, bool includeCountry = true) => await DbSet.AnyAsync(GetPredicate(Helper.GetPredicateIsExist<T, TDto>(dto, includeCountry), isDelete, isOrganization));
        public async Task<bool> IsExistAnyAsync(Expression<Func<T, bool>> predicate, Guid? organizationId = null, bool isDelete = true, bool isOrganization = true) => organizationId == null ? await DbSet.AnyAsync(GetPredicate(predicate, isDelete, isOrganization)) : await DbSet.AnyAsync(GetPredicate(predicate, isDelete, false).And(q => q.OrganizationId == organizationId));
        public async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null, bool isDelete = true, bool isOrganization = true) => predicate == null ? await DbSet.CountAsync(GetPredicate(isDelete: isDelete, isOrganization: isOrganization)) : await DbSet.CountAsync(GetPredicate(predicate, isDelete, isOrganization));


        public async Task<IEnumerable<TType>> FindSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isDelete, isOrganization));
            if (pagingSortingDto != null) query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            return await query.Select(select).ToListAsync();
        }

        public async Task<TType> FirstOrDefaultSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, PagingSortingDto pagingSortingDto = null, bool disableTracking = false, bool isDelete = true, bool isOrganization = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isDelete, isOrganization));
            if (pagingSortingDto != null) query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField);
            if (include != null) query = include(query).AsSplitQuery();
            if (orderBy != null) query = orderBy(query);
            return await query.Select(select).FirstOrDefaultAsync();
        }
        public async Task<(IEnumerable<TType>, int)> GetPagedListSelectAsync<TType>(Expression<Func<T, bool>> predicate, Expression<Func<T, TType>> select, PagingSortingDto pagingSortingDto, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool sortFromAnotherService = false, bool disableTracking = false, bool isDelete = true, bool isOrganization = true, Expression<Func<T, bool>> predicateUnion = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,bool getCount=true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking) query = query.AsNoTracking();
            query = query.Where(GetPredicate(predicate, isOrganization: isOrganization));
            if (!sortFromAnotherService && pagingSortingDto.SortField != "")
                query = query.OrderByWithDirection(pagingSortingDto.SortDirection, pagingSortingDto.SortField, orderBy);
            if (sortFromAnotherService && orderBy != null) query = orderBy(query);

            if (include != null) query = include(query).AsSplitQuery();
            var count = 0;
            if (getCount)
                count = await query.CountAsync(); 
            var queryData = pagingSortingDto.Limit == 1 ? query : query.GetPaggedList(pagingSortingDto.Offset, pagingSortingDto.Limit ?? 10);
            if (predicateUnion == null) return (await queryData.Select(select).ToListAsync(), count);
            IQueryable<T> queryUnion = DbSet;
            var unionData = queryUnion.Where(GetPredicate(predicateUnion, isDelete, isOrganization));
            if (include != null) unionData = include(unionData).AsSplitQuery();
            var result = queryData.Union(unionData);
            return (await result.Select(select).ToListAsync(), count);
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
        public async Task<T> AddAsync(T entity, bool? auditSave = true, bool? contextSave = true)
        {
            try
            {
                if (auditSave == true)
                {
                    var scopeName = entity.GetType().Name;
                    var eventType = scopeName;
                    var options = new AuditScopeOptions()
                    {
                        EventType = eventType,
                        TargetGetter = () => entity,
                        AuditEvent = new AuditCustomEvent()
                        {
                            ActionID = (int)Audit_ActionEnum.Add,
                            UserId = AuditTransaction.UserId,
                            UserName = AuditTransaction.UserName,
                            OrganizationId = _sessionStorage.OrganizationId.ToString()
                        },
                    };
                    // ReSharper disable once UseAwaitUsing
                    using var scope = AuditScope.Create(options);
                    scope.Event.Target.Old = null;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return contextSave == true ? (await DbSet.AddAsync(entity)).Entity : entity;
        }
        public async Task AddRangeAsync(IEnumerable<T> entities, bool? auditSave = true, bool? contextSave = true)
        {
            var baseEntityModels = entities.ToList();
            if (baseEntityModels.Count != 0 && auditSave == true)
            {
                var options = new AuditScopeOptions()
                {
                    EventType = baseEntityModels.FirstOrDefault()?.GetType().Name,
                    TargetGetter = () => entities,
                    AuditEvent = new AuditCustomEvent()
                    {
                        ActionID = (int)Audit_ActionEnum.AddRange,
                        UserId = AuditTransaction.UserId,
                        UserName = AuditTransaction.UserName,
                        OrganizationId = _sessionStorage.OrganizationId.ToString(),
                        
                    },
                };
                // ReSharper disable once UseAwaitUsing
                using var scope = AuditScope.Create(options);
                scope.Event.Target.Old = null;
            }

            if (contextSave == true)
            {
                await DbSet.AddRangeAsync(baseEntityModels);
            }
        }
        public async Task RemoveAsync(T entity, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() =>
            {
                if (contextSave == true)
                {
                    entity.IsDelete = true;

                }

                if (auditSave != true) return;
                var options = new AuditScopeOptions()
                {
                    EventType = entity.GetType().Name,
                    TargetGetter = () => null,
                    AuditEvent = new AuditCustomEvent()
                    {
                        ActionID = (int)Audit_ActionEnum.Delete,
                        UserId = AuditTransaction.UserId,
                        UserName = AuditTransaction.UserName,
                        OrganizationId = _sessionStorage.OrganizationId.ToString()
                    },
                };
                using var scope = AuditScope.Create(options);
                scope.Event.Target.Old = entity;
            });
            await task;
        }
        public async Task RemovePhysicalAsync(T entity, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() =>
            {
                if (auditSave == true)
                {
                    var options = new AuditScopeOptions()
                    {
                        EventType = entity.GetType().Name,
                        TargetGetter = () => null,
                        AuditEvent = new AuditCustomEvent()
                        {
                            ActionID = (int)Audit_ActionEnum.Delete,
                            UserId = AuditTransaction.UserId,
                            UserName = AuditTransaction.UserName,
                            OrganizationId = _sessionStorage.OrganizationId.ToString()
                        },
                    };
                    using var scope = AuditScope.Create(options);
                    scope.Event.Target.Old = entity;
                }

                if (contextSave == true)
                {
                    DbSet.Remove(entity);
                }
            });
            await task;
        }
        public async Task RemoveRangeAsync(IEnumerable<T> entities, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var baseEntityModels = entities.ToList();
                if (baseEntityModels.Count() != 0 && auditSave == true)
                {
                    var scopeName = baseEntityModels.FirstOrDefault()?.GetType().Name;
                    var eventType = scopeName;
                    var options = new AuditScopeOptions()
                    {
                        EventType = eventType,
                        TargetGetter = () => null,
                        AuditEvent = new AuditCustomEvent()
                        {
                            ActionID = (int)Audit_ActionEnum.DeleteRange,
                            UserId = AuditTransaction.UserId,
                            UserName = AuditTransaction.UserName,
                            OrganizationId = _sessionStorage.OrganizationId.ToString()
                        },
                    };
                    using var scope = AuditScope.Create(options);
                    scope.Event.Target.Old = entities;
                }

                if (contextSave == true)
                {
                    DbSet.RemoveRange(baseEntityModels);
                }
            });
            await task;
        }
        public async Task UpdateAsync(T entityNew, T entityOld, bool? auditSave = true, bool? contextSave = true)
        {
            var task = Task.Factory.StartNew(() =>
            {
                if (auditSave == true)
                {
                    var scopeName = entityNew.GetType().Name;
                    var eventType = scopeName;
                    var @new = entityNew;
                    var options = new AuditScopeOptions()
                    {
                        EventType = eventType,
                        TargetGetter = () => @new,
                        AuditEvent = new AuditCustomEvent()
                        {
                            ActionID = (int)Audit_ActionEnum.Update,
                            UserId = AuditTransaction.UserId,
                            UserName = AuditTransaction.UserName,
                            OrganizationId = _sessionStorage.OrganizationId.ToString(),
                        },
                        
                    };
                    using var scope = AuditScope.Create(options);
                    scope.Event.Target.Old = entityOld;
                }
                if (contextSave != true) return;
                entityNew = Helper.EditOriginalValues(entityNew, entityOld);
                Context.Entry(entityOld).State = EntityState.Detached; // exception when trying to change the state
                Context.Entry(entityNew).State = EntityState.Modified; // exception when trying to change the state
                Context.Entry(entityOld).CurrentValues.SetValues(entityNew);
            });
            await task;
        }
        //Under Test
        public async Task UpdateRangeAsync(IEnumerable<T> entityNew, IEnumerable<T> entityOld)
        {
            await RemoveRangeAsync(entityOld);
            await AddRangeAsync(entityNew);
        }
        public async Task UpdateRangeAsync(IEnumerable<T> entityNew)
        {
            var task = Task.Factory.StartNew(() => Context.UpdateRange(entityNew));
            await task;
        }
        public IQueryable<T> GetAllAsQueryable(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool asSplitQuery = true, bool isOrganization = true)
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
            return query;
        }
      
        public async Task<IQueryable<TType>> GetAllWithSelectAsQueryable<TType>(Expression<Func<T, TType>> select,Expression<Func<T, bool>> predicate = null,Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,bool asSplitQuery = true,bool isOrganization = true) where TType : class
        {
            IQueryable<T> query = DbSet;
            if (include != null)
            {
                query = asSplitQuery? include(query).AsSplitQuery(): include(query).AsSingleQuery();
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
