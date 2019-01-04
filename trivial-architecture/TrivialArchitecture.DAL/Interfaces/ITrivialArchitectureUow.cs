using TrivialArchitecture.DAL.Interfaces.CustomRepositories;
using TrivialArchitecture.DAL.Models.Entities.Cars;

namespace TrivialArchitecture.DAL.Interfaces
{
	public interface ITrivialArchitectureUow
	{
		void Commit();

		ICarDriversRepository CarDrivers { get; }

		ICarsRepository Cars { get; }
	}
}
