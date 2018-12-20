namespace ORM.DAL.Models.Entities
{
	// Example of "Table per Hierarchy"
	public class PassengerCar : Car
	{
		public int NumberOfSeats { get; set; }
	}
}
