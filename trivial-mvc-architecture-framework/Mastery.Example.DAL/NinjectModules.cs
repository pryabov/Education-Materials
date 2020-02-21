using Mastery.Example.DAL.Common.Interfaces;
using Ninject.Modules;

namespace Mastery.Example.DAL
{
    public class NinjectModules : NinjectModule
    {
        public override void Load()
        {
            Bind<ShopDbContext>().ToSelf();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
