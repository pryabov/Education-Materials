using System.ComponentModel.DataAnnotations;

namespace ORM.DAL.Models.Entities
{
	public class CarDriver : IBaseEntity<long>
	{
		public long Id { get; set; }

		[MaxLength(255)]
		public string FirstName { get; set; }

		[MaxLength(255)]
		public string LastName { get; set; }

		[Range(18, 100)]
		public int Age { get; set; }

		public virtual Car Car { get; set; }
		public long? CarId { get; set; }
	}
}
