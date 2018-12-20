using ORM.DAL.Interfaces.CustomRepositories;
using ORM.DAL.Models.Entities;

namespace ORM.DAL.Interfaces
{
	public interface IORMUow
	{
		void Commit();

		ICarDriversRepository CarDrivers { get; }

		IRepository<Car> Cars { get; }
	}
}
