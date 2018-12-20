using System;
using System.Linq;
using ORM.BusinessLogic.Interfaces;
using ORM.DAL.Interfaces;
using ORM.DAL.Models.Entities;
using ORM.DAL.Models.Enums;

namespace ORM.BusinessLogic.Core
{
	public class CarService : BaseService, ICarService
	{
		public CarService(IORMUow uow) : base(uow) { }

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

			Uow.Cars.Create(newCar);

			Uow.Commit();
		}
	}
}
