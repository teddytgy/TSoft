#region

using TSoft.Data;
using TSoft.Data.Mappings;
using TSoft.Entities.Models;
using TSoft.Repository.Interfaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

#endregion

namespace TSoft.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TSoftContext DbContext { get; set; }

        #region Constructor

        public UnitOfWork()            
        {
            CreateDbContext();
        }

        #endregion Constructor

        #region Repositories

        private IRepository<Log4Net_Error> _log4Net_Error;
        public IRepository<Log4Net_Error> Log4Net_Error
        {
            get { return _log4Net_Error ?? (_log4Net_Error = new Repository<Log4Net_Error>(DbContext)); }
        }

        private IRepository<UserProfile> _userProfile;
        public IRepository<UserProfile> UserProfile
        {
            get { return _userProfile ?? (_userProfile = new Repository<UserProfile>(DbContext)); }
        }        

        #endregion       

        protected void CreateDbContext()
        {
            DbContext = new TSoftContext();

            // Do NOT enable proxied entities, else serialization fails
            //if false it will not get the associated certification and skills when we get the applicants
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }        

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion

    }
}