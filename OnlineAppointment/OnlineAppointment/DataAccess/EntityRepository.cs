using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineAppointment.Models;

namespace OnlineAppointment.DataAccess
{
    public class EntityRepository<T>:IEntityRepository<T> where T:class,new()
    
    {
        private AppointmentContext _dbContext;
        private DbSet<T> _dbSet;

        public EntityRepository(AppointmentContext dbcontext)
        {
            _dbContext = dbcontext;
            _dbSet = _dbContext.Set<T>();
        }
        public virtual void Insert (T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();

        }
        public IQueryable<T> GetAllQuerable()
        {
            return _dbSet;
        }

       
    }

}
