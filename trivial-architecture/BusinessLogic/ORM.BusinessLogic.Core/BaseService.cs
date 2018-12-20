using ORM.DAL.Interfaces;

namespace ORM.BusinessLogic.Core
{
	public abstract class BaseService
	{
		protected IORMUow Uow;

		protected BaseService(IORMUow uow)
		{
			Uow = uow;
		}
	}
}
