using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Insurance.Application.Repositories
{
    public interface IBaseRepository<TClass> where TClass : class
    {
        public Task<TClass> GetAsync(int id);
        public Task<IEnumerable<TClass>> GetAllAsync();
        public Task<IEnumerable<TClass>> GetAllAsync(int page, int pageSize);
        public Task<IEnumerable<TClass>> FindAsync(Expression<Func<TClass, bool>> predicate);
        public Task<TClass> CreateAsync(TClass item);
        public Task<IEnumerable<TClass>> CreateRangeAsync(IEnumerable<TClass> items);
        public Task UpdateAsync(TClass item);
        public Task RemoveAsync(TClass item);
    }
}
