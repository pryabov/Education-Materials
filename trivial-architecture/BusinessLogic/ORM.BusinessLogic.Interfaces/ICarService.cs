using System.Linq;
using ORM.DAL.Models.Entities;

namespace ORM.BusinessLogic.Interfaces
{
	public interface ICarService
	{
		IQueryable<Car> GetAll();

		void CreateRandomCar();
	}
}
