using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrivialArchitecture.DAL.Entities.Books
{
	[Table("Tags")]
	public class Tag : IBaseEntity<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Book> Books { get; set; }
	}
}
