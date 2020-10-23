using System.Linq;

namespace OnlineAppointment.DataAccess
{
    public interface IEntityRepository<T> where T:class,new()
    {
        void Insert(T entity);
        IQueryable<T> GetAllQuerable();
    }
}