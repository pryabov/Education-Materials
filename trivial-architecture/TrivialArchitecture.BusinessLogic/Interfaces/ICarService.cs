﻿using System.Linq;
using TrivialArchitecture.DAL.Models.Entities.Cars;

namespace TrivialArchitecture.BusinessLogic.Interfaces
{
	public interface ICarService
	{
		IQueryable<Car> GetAll();

		void CreateRandomCar();

		void CreateCar(Car newCar);
	}
}
