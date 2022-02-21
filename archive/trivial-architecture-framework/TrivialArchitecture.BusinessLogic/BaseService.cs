using TrivialArchitecture.DAL;

namespace TrivialArchitecture.BusinessLogic
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
