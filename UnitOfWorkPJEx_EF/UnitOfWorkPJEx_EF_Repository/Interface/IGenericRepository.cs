using System.Linq.Expressions;

namespace UnitOfWorkPJEx_EF_Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //TEntity? GetById(int id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
  string includeProperties = "");

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
