using System.Collections.Generic;

namespace TrivialArchitecture.DAL.Models.Entities.Books
{
	[Table("Tags")]
	public class Tag : IBaseEntity<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Book> Books { get; set; }
	}
}
