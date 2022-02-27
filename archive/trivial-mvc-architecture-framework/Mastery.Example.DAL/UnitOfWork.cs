using Mastery.Example.DAL.Common.Interfaces;
using Mastery.Example.DAL.Repositories;

namespace Mastery.Example.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext context;

        public UnitOfWork(ShopDbContext context) 
            => this.context = context;

        public IGenericRepository<TModel> GetGenericRepository<TModel>() where TModel : class, new() 
            => new GenericRepository<TModel>(context);

        public int SaveChanges()
            => context.SaveChanges();
    }
}
