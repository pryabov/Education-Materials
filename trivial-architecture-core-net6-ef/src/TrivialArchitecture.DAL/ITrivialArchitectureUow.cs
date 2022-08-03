using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL
{
	public interface ITrivialArchitectureUow
	{
		void Commit();

		ICarDriversRepository CarDrivers { get; }

		ICarsRepository Cars { get; }
	}
}
