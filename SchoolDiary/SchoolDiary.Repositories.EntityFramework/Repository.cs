namespace SchoolDiary.Repositories.EntityFramework
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IRepository
    {
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        bool Delete<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> FilterBy<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }

    public class Repository : IRepository
    {
        private readonly SchoolDiaryDbContext _dbContext;
        public Repository(SchoolDiaryDbContext schoolDiaryDbContext)
        {
            _dbContext = schoolDiaryDbContext;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public IQueryable<TEntity> FilterBy<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Where(filter);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public TEntity Update<TEntity>(TEntity updated) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Update(updated).Entity;
        }
    }
}
