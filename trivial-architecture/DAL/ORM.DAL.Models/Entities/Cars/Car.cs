using System.Collections;
using ORM.DAL.Models.Enums;

namespace ORM.DAL.Models.Entities
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
