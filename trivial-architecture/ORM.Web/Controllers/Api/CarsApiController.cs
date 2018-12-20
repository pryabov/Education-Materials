using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ORM.BusinessLogic.Interfaces;
using ORM.DAL.Models.Entities;

namespace ORM.Web.Controllers.Api
{
	[RoutePrefix("api/cars")]
	public class CarsApiController : ApiController
	{
		private readonly ICarService _carService;

		public CarsApiController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet]
		[Route("")]
		public List<Car> GetAll()
		{
			List<Car> cars = _carService.GetAll().ToList();
			return cars;
		}

		[HttpPost]
		[Route("addRandomCar")]
		public void AddRandomCar()
		{
			_carService.CreateRandomCar();
		}
	}
}
