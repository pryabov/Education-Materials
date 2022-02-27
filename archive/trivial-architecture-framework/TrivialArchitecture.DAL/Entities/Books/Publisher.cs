using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrivialArchitecture.DAL.Entities.Books
{
	public class Publisher : IBaseEntity<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		public string Test { get; set; }

		public virtual ICollection<Book> Books { get; set; }
	}
}
