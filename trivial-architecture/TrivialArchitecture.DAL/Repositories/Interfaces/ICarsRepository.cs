using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL.Repositories.Interfaces
{
	public interface ICarsRepository : IRepository<Car>
	{
		Car GetByNumber(string number);
	}
}
