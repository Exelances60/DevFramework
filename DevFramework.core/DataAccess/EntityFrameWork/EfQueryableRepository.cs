using DevFramework.core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.core.DataAccess.EntityFrameWork
{
    public class EfQueryableRepository<T>:IQueryableRepository<T> where T : class,IEntity,new()
    {
        private DbContext _context; 
        private DbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
