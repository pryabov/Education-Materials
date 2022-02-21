using CommandLine;
using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.BusinessLogic.Interfaces;
using TrivialArchitecture.DAL.Entities.Cars;
using TrivialArchitecture.UI.Console.CommandLineVerbs;
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
		public void ParseCommand(string[] args)
		{
			Parser.Default.ParseArguments<ListCommandLineVerb, AddCarCommandLineVerb>(args)
				.WithParsed<ListCommandLineVerb>(opts => PrintEntitiesList())
				.WithParsed<AddCarCommandLineVerb>(AddCar);
		}

		private void PrintEntitiesList()
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

		private void AddCar(AddCarCommandLineVerb opts)
		{
			carService.CreateCar(new Car
			{
				Brand = opts.Brand,
				Color = opts.Color,
				Number = opts.Number,
				Odometer = opts.Odometer
			});
		}
	}
}
