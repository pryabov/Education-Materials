using TrivialArchitecture.DAL.Interfaces;

namespace TrivialArchitecture.BusinessLogic.Core
{
	public abstract class BaseService
	{
		protected ITrivialArchitectureUow Uow;

		protected BaseService(ITrivialArchitectureUow uow)
		{
			Uow = uow;
		}
	}
}
