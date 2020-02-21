using System;
using System.Linq;
using TrivialArchitecture.BusinessLogic.Interfaces;
using TrivialArchitecture.DAL;
using TrivialArchitecture.DAL.Entities.Cars;
using TrivialArchitecture.DAL.Entities.Cars.Enums;

namespace TrivialArchitecture.BusinessLogic
{
	public class CarService : BaseService, ICarService
	{
		public CarService(ITrivialArchitectureUow uow) : base(uow) { }

		public IQueryable<Car> GetAll()
		{
			return Uow.Cars.GetAll();
		}

		public void CreateRandomCar()
		{
			Random rand = new Random();

			Car newCar = new Car
			{
				Number = $"Number_{rand.Next()}",
				Odometer = Math.Round(rand.NextDouble() * 1000, 2),
				Brand = CarBrand.Lada,
				Color = CarColor.White
			};

			CreateCar(newCar);
		}

		public void CreateCar(Car newCar)
		{
			if (newCar == null)
			{
				throw new ArgumentNullException(nameof(newCar));
			}

			Car carByNumber = Uow.Cars.GetByNumber(newCar.Number);
			if (carByNumber != null)
			{
				throw new InvalidOperationException($"Car number '{newCar.Number}' already exists.");
			}

			Uow.Cars.Create(newCar);
			Uow.Commit();
		}
	}
}
