using System.Data.Entity;
using TrivialArchitecture.DAL.Interfaces.CustomRepositories;
using TrivialArchitecture.DAL.Models.Entities.Cars;

namespace TrivialArchitecture.DAL.Repositories
{
	public class CarDriversRepository : BaseRepository<CarDriver>, ICarDriversRepository
	{
		public CarDriversRepository(DbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
