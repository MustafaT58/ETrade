using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        TradeContext _db;
        public BaseRepository(TradeContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            Set().Add(entity);
            return true;
        }

        public bool Delete(int Id)
        {
            Set().Remove(Find(Id));
            return true;
        }
        public bool Delete(int Id, int Id2)
        {
            Set().Remove(Find(Id,Id2));
            return true;
        }


        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Find(int Id, int Id2)
        {
            return Set().Find(Id,Id2);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            Set().Update(entity);
            return true;
        }
    }
}
