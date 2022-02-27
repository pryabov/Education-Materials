using Microsoft.EntityFrameworkCore;
using TrivialArchitecture.DAL.Entities.Cars;
using TrivialArchitecture.DAL.Repositories.Interfaces;

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
