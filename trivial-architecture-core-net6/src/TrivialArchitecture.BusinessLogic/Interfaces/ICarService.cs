using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.BusinessLogic.Interfaces
{
	public interface ICarService
	{
		IList<Car> GetAll();

		void CreateRandomCar();

		void CreateCar(Car newCar);
	}
}
