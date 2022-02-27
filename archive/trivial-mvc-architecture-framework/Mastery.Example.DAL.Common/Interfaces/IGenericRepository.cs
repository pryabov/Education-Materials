using System.Linq;

namespace Mastery.Example.DAL.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetQuery();

        IQueryable<TEntity> GetQueryAsNoTracking();

        TEntity Add(TEntity model);

        TEntity Update(TEntity model);

        void Delete(TEntity model);
    }
}
