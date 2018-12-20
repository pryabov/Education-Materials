using System.Collections;
using TrivialArchitecture.DAL.Models.Enums;

namespace TrivialArchitecture.DAL.Models.Entities.Cars
{
	public class Car: IBaseEntity<long>
	{
		public long Id { get; set; }

		public CarBrand Brand { get; set; }

		public CarColor Color { get; set; }

		public string Number { get; set; }

		public double Odometer { get; set; }

		public virtual ICollection CarDrivers { get; set; }
	}
}
