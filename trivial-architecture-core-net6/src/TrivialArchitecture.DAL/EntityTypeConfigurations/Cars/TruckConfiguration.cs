using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL.EntityTypeConfigurations.Cars
{
	public class TruckConfiguration : IEntityTypeConfiguration<Truck>
	{
		public void Configure(EntityTypeBuilder<Truck> builder)
		{
			builder.ToTable("Cars");
		}
	}
}
