using WiredBrainCoffee.StorageApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext) {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public event EventHandler<T>? ItemAdded;

        public IEnumerable<T> GetAll() {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetByID(int id) => _dbSet.Find(id);

        public void Add(T item) {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Save() {
            _dbContext.SaveChanges();
        }

        public void Remove(T item) {
            _dbSet.Remove(item);
        }
    }
}
