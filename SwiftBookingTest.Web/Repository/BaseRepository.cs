using StructureMap;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SwiftBookingTest.Web.Repository
{
    /// <summary>
    /// Base Repository
    /// </summary>
    public abstract class BaseRepository<TDomainClass> : IBaseRepository<TDomainClass, int>
       where TDomainClass : class
    {
        #region Private

        private readonly IContainer container;
        #endregion
        #region Protected

        /// <summary>
        /// Primary database set
        /// </summary>
        protected abstract IDbSet<TDomainClass> DbSet { get; }
        #endregion
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseRepository(IContainer container)
        {

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
            //TODO: No need anny
            //string connectionString = ConfigurationManager.ConnectionStrings["SwiftBookingDbContext"].ConnectionString;
            db = container.GetInstance<SwiftBookingDbContext>();

        }

        #endregion
        #region Public
        /// <summary>
        /// base Db Context
        /// </summary>
        public SwiftBookingDbContext db;
        /// <summary>
        /// Get all
        /// </summary>
        public virtual IQueryable<TDomainClass> GetAll(TDomainClass instance)
        {
            return DbSet.Find(instance) as IQueryable<TDomainClass>;
        }

        /// <summary>
        /// Create object instance
        /// </summary>
        public virtual TDomainClass Create()
        {
            TDomainClass result = container.GetInstance<TDomainClass>();
            return result;
        }
        /// <summary>
        /// Find entry by key
        /// </summary>
        public virtual IQueryable<TDomainClass> Find(TDomainClass instance)
        {
            return DbSet.Find(instance) as IQueryable<TDomainClass>;
        }
        /// <summary>
        /// Find Entity by Id
        /// </summary>
        public TDomainClass Find(int id)
        {
            return DbSet.Find(id);
        }
        /// <summary>
        /// Get All Entites 
        /// </summary>
        /// <returns></returns>
        public IQueryable<TDomainClass> GetAll()
        {
            return DbSet;
        }
        /// <summary>
        /// Save Changes in the entities
        /// </summary>
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        /// <summary>
        /// Delete an entry
        /// </summary>
        public virtual void Delete(TDomainClass instance)
        {
            DbSet.Remove(instance);

        }
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Add(TDomainClass instance)
        {
            DbSet.Add(instance);
        }
        /// <summary>
        /// Add an entry
        /// </summary>
        public virtual void Update(TDomainClass instance)
        {
            DbSet.AddOrUpdate(instance);
        }
        #endregion
    }
}