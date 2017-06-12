using System.Linq;

namespace SwiftBookingTest.Web.Repository
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    public interface IBaseRepository<TDomainClass, TKeyType>
        where TDomainClass : class
    {
        /// <summary>
        /// Create object instance
        /// </summary>
        /// <returns>object instance</returns>
        TDomainClass Create();                
        /// <summary>
        /// Add an entry
        /// </summary>
        /// <param name="instance"></param>
        void Add(TDomainClass instance);        
        /// <summary>
        /// Find by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TDomainClass Find(TKeyType id);        
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IQueryable<TDomainClass> GetAll();
        /// <summary>
        /// Save changes
        /// </summary>
        void SaveChanges();
        /// <summary>        
    }
}