using Microsoft.EntityFrameworkCore;
using WorkBench.DB;
using WorkBench.Repository.Interfaces;

namespace WorkBench.Repository
{
    // Generic Repository Implementation
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WorkBenchDbContext _context;
        public Repository(WorkBenchDbContext context) => _context = context;

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task UpdateAsync(T entity) => _context.Set<T>().Update(entity);
        public async Task DeleteAsync(int id)=> _context.Set<T>().Remove(await GetByIdAsync(id) ?? throw new ArgumentException("Entity not found"));
    }
}
