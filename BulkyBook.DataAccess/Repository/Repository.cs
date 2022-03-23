using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T Entity)
        {
            dbSet.Add(Entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void RemoveRange(T Entity)
        {
           dbSet.RemoveRange(Entity);
        }
    }
}
