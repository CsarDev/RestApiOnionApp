using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
	{
		public DbContext _context { get; set; }

		public GenericRepository(DbContext context)
		{
			this._context = context;
		}

		public T Get(Guid Id)
		{
			return _context.Set<T>().Find(Id);
		}

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            this.SaveChanges();
        }

        public void Delete(T value)
        {
            var entity =  _context.Set<T>().Find(value);

            if (entity == null)
            {
                return ;
            }

            _context.Set<T>().Remove(entity);

            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {           
            _context.Set<T>().Update(entity);
            this.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
