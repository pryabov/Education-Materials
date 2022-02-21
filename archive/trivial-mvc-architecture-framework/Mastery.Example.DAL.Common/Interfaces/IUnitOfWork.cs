namespace Mastery.Example.DAL.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TModel> GetGenericRepository<TModel>()
            where TModel : class, new();

        int SaveChanges();
    }
}
