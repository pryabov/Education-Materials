using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrivialArchitecture.DAL.Entities.Cars;

namespace TrivialArchitecture.DAL.EntityTypeConfigurations.Cars
{
	public class CarConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.ToTable("Cars");

			builder.HasMany(item => item.CarDrivers);

			// https://docs.microsoft.com/en-us/ef/core/modeling/inheritance
			builder.HasDiscriminator<int>("Type")
				.HasValue<Car>(1)
				.HasValue<Truck>(2)
				.HasValue<PassengerCar>(3);
		}
	}
}
