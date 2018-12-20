using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.DAL.Models.Entities
{
	// Example of "Table per Type"
	[Table("Trucks")]
	public class Truck : Car
	{
		public string Name { get; set; }
	}
}
