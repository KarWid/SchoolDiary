namespace SchoolDiary.Repositories.EntityFramework
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();
        Task<int> CountAsync();
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Skip(int skip);
        IQueryable<TEntity> Take(int take);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Skip(int skip)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Take(int take)
        {
            throw new NotImplementedException();
        }
    }
}
