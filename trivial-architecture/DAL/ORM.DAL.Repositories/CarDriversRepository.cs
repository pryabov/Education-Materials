using System.Data.Entity;
using ORM.DAL.Interfaces.CustomRepositories;
using ORM.DAL.Models.Entities;

namespace ORM.DAL.Repositories
{
	public class CarDriversRepository : BaseRepository<CarDriver>, ICarDriversRepository
	{
		public CarDriversRepository(DbContext dbContext)
			: base(dbContext)
		{
		}
	}
}
