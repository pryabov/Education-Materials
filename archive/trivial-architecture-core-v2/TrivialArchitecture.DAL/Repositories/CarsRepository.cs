using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrivialArchitecture.DAL.Entities.Cars;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL.Repositories
{
	public class CarsRepository : BaseRepository<Car>, ICarsRepository
	{
		public CarsRepository(DbContext dbContext)
			: base(dbContext)
		{
		}

		public Car GetByNumber(string number)
		{
			Car result = DbSet.FirstOrDefault(car => car.Number.Equals(number));
			return result;
		}
	}
}
