using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Repository.Generic
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        protected readonly BookCartDBContext _context;

        protected GenericRepository(BookCartDBContext context)
        {
            _context = context;
        }

        public async Task<T> Get(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            this._context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            this._context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            this._context.SaveChanges();
        }
        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
