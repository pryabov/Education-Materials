using System.ComponentModel.DataAnnotations.Schema;

namespace TrivialArchitecture.DAL.Models.Entities.Cars
{
	// Example of "Table per Type"
	[Table("Trucks")]
	public class Truck : Car
	{
		public string Name { get; set; }
	}
}
