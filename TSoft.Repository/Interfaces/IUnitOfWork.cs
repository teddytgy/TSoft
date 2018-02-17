using System;
using TSoft.Entities.Models;

namespace TSoft.Repository.Interfaces
{
    /// <summary>
    /// Base interface to implement UnitOfWork Pattern.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit all changes made in a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,  
        /// then an exception is thrown
        ///</remarks>
        void Commit();

        IRepository<UserProfile> UserProfile { get; }

        IRepository<Log4Net_Error> Log4Net_Error { get; }
        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then 'client changes' are refreshed - Client wins
        ///</remarks>
        //void CommitAndRefreshChanges();


        /// <summary>
        /// Rollback tracked changes. See references of UnitOfWork pattern
        /// </summary>
        //void RollbackChanges();

    }
}