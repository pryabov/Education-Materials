using System.Data.Entity;
using System.Linq;
using TrivialArchitecture.DAL.Interfaces.CustomRepositories;
using TrivialArchitecture.DAL.Models.Entities.Cars;

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
