using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Insurance.Application.Repositories;

namespace Insurance.Infrastructure.Persistence
{
    public class BaseRepository<TClass> : IBaseRepository<TClass>
        where TClass : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TClass> GetAsync(int id)
        {
            return await _context.Set<TClass>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TClass>> GetAllAsync()
        {
            return await _context.Set<TClass>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TClass>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Set<TClass>().Skip(page * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TClass>> FindAsync(Expression<Func<TClass, bool>> predicate)
        {
            return await _context.Set<TClass>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public virtual async Task<TClass> CreateAsync(TClass item)
        {
            await _context.Set<TClass>().AddAsync(item);
            await _context.SaveChangesAsync();

            _context.Entry(item).State = EntityState.Detached;
            return item;
        }

        public virtual async Task<IEnumerable<TClass>> CreateRangeAsync(IEnumerable<TClass> items)
        {
            await _context.Set<TClass>().AddRangeAsync(items);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Detached;
            }

            return items;
        }

        public virtual async Task UpdateAsync(TClass item)
        {
            _context.Attach(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _context.Entry(item).State = EntityState.Detached;
        }

        public virtual async Task RemoveAsync(TClass item)
        {
            _context.Attach(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            _context.Entry(item).State = EntityState.Detached;
        }
    }
}
