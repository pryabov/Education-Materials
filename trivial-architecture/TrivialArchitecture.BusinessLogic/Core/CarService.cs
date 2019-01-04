﻿using System;
using System.Linq;
using TrivialArchitecture.BusinessLogic.Interfaces;
using TrivialArchitecture.DAL.Interfaces;
using TrivialArchitecture.DAL.Models.Entities.Cars;
using TrivialArchitecture.DAL.Models.Enums;

namespace TrivialArchitecture.BusinessLogic.Core
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

			Uow.Cars.GetById()

			Uow.Cars.Create(newCar);

			Uow.Commit();
		}

	}
}
