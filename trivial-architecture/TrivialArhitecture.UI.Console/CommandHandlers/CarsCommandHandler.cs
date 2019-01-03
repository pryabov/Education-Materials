using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.BusinessLogic.Interfaces;
using TrivialArchitecture.DAL.Models.Entities.Cars;
using TrivialArchitecture.UI.Console.Utils.Interfaces;

namespace TrivialArchitecture.UI.Console.CommandHandlers
{
	public class CarsCommandHandler
	{
		private readonly IColorfulConsole colorfulConsole;
		private readonly ICarService carService;

		public CarsCommandHandler(IColorfulConsole colorfulConsole, ICarService carService)
		{
			this.colorfulConsole = colorfulConsole;
			this.carService = carService;
		}

		public void PrintEntitiesList()
		{
			List<Car> cars = carService.GetAll().ToList();

			if (cars.Any())
			{
				foreach (Car car in cars)
				{
					colorfulConsole.WriteLine($"Brand: {car.Brand}; Number: {car.Number}; Color: {car.Color}; Odometer: {car.Odometer}.");
				}

				colorfulConsole.WriteLine(string.Empty);
			}
			else
			{
				colorfulConsole.WriteLine("---- No Items ----");
			}
		}
	}
}
