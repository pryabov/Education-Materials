namespace TrivialArchitecture.DAL.Models.Entities.Cars
{
	// Example of "Table per Hierarchy"
	public class PassengerCar : Car
	{
		public int NumberOfSeats { get; set; }
	}
}
