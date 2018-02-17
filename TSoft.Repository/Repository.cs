#region

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TSoft.Repository.Interfaces;

#endregion

namespace TSoft.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
         public Repository(DbContext dbContext)
        {
            if (dbContext == null) 
                throw new ArgumentNullException("Null DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }
 
        protected DbContext DbContext { get; set; }
 
        protected DbSet<T> DbSet { get; set; }
 
        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }
 
        public virtual T GetById(int id)
        {           
            return DbSet.Find(id);
        }
 
        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }
 
        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }  
            dbEntityEntry.State = EntityState.Modified;
        }
 
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }
 
        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        //#region Members

        //IQueryableUnitOfWork _UnitOfWork;

        //#endregion

        //#region Constructor

        ///// <summary>
        ///// Create a new instance of repository
        ///// </summary>
        ///// <param name="unitOfWork">Associated Unit Of Work</param>
        //public Repository(IQueryableUnitOfWork unitOfWork)
        //{
        //    if (unitOfWork == (IUnitOfWork)null)
        //        throw new ArgumentNullException("unitOfWork");

        //    _UnitOfWork = unitOfWork;
        //}

        //#endregion

        //#region IRepository Members

        ///// <summary>
        ///// 
        ///// </summary>
        //public IUnitOfWork UnitOfWork
        //{
        //    get
        //    {
        //        return _UnitOfWork;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void Add(T item)
        //{

        //    if (item != (T)null)
        //        GetSet().Add(item); // add new item in this set
        //    else
        //    {
        //        LoggerFactory.CreateLog()
        //                  .LogInfo(Message.info_CannotAddNullEntity, typeof(T).ToString());

        //    }

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void Remove(T item)
        //{
        //    if (item != (T)null)
        //    {
        //        //attach item if not exist
        //        _UnitOfWork.Attach(item);

        //        //set as "removed"
        //        GetSet().Remove(item);
        //    }
        //    else
        //    {
        //        LoggerFactory.CreateLog()
        //                  .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void TrackItem(T item)
        //{
        //    if (item != (T)null)
        //        _UnitOfWork.Attach<T>(item);
        //    else
        //    {
        //        LoggerFactory.CreateLog()
        //                  .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="item"></param>
        //public virtual void Modify(T item)
        //{
        //    if (item != (T)null)
        //        _UnitOfWork.SetModified(item);
        //    else
        //    {
        //        LoggerFactory.CreateLog()
        //                  .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public virtual T Get(int id)
        //{
        //    if (id != 0)
        //        return GetSet().Find(id);
        //    else
        //        return null;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public virtual IEnumerable<T> GetAll()
        //{
        //    return GetSet();
        //}       

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TKProperty"></typeparam>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageCount"></param>
        ///// <param name="orderByExpression"></param>
        ///// <param name="ascending"></param>
        ///// <returns></returns>
        //public virtual IEnumerable<T> GetPaged<TKProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<T, TKProperty>> orderByExpression, bool ascending)
        //{
        //    var set = GetSet();

        //    if (ascending)
        //    {
        //        return set.OrderBy(orderByExpression)
        //                  .Skip(pageCount * pageIndex)
        //                  .Take(pageCount);
        //    }
        //    else
        //    {
        //        return set.OrderByDescending(orderByExpression)
        //                  .Skip(pageCount * pageIndex)
        //                  .Take(pageCount);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //public virtual IEnumerable<T> GetFiltered(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        //{
        //    return GetSet().Where(filter);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="persisted"></param>
        ///// <param name="current"></param>
        //public virtual void Merge(T persisted, T current)
        //{
        //    _UnitOfWork.ApplyCurrentValues(persisted, current);
        //}

        //#endregion

        //#region IDisposable Members

        ///// <summary>
        ///// <see cref="M:System.IDisposable.Dispose"/>
        ///// </summary>
        //public void Dispose()
        //{
        //    if (_UnitOfWork != null)
        //        _UnitOfWork.Dispose();
        //}

        //#endregion

        //#region Private Methods

        //IDbSet<T> GetSet()
        //{
        //    return _UnitOfWork.CreateSet<T>();
        //}
        //#endregion

    }
}