using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL.EntityTypeConfigurations.Cars
{
	public class CarDriverConfiguration : IEntityTypeConfiguration<CarDriver>
	{
		public void Configure(EntityTypeBuilder<CarDriver> builder)
		{
			builder.ToTable("CarDrivers");
		}
	}
}
