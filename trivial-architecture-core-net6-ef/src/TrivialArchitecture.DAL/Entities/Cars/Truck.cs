using System.ComponentModel.DataAnnotations.Schema;

namespace TrivialArchitecture.DAL.Entities.Cars
{
	// Example of "Table per Type"
	[Table("Trucks")]
	public class Truck : Car
	{
		public string CompanyName { get; set; }
	}
}
