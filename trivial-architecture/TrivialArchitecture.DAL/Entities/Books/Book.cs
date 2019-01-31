using System.Collections.Generic;
using TrivialArchitecture.DAL.Entities.Books.Enums;

namespace TrivialArchitecture.DAL.Entities.Books
{
	public class Book : IBaseEntity<long>
	{
		/* Some Properties */
		public long Id { get; set; }

		public string Name { get; set; }

		public Language Language { get; set; }

		public virtual Publisher Publisher { get; set; }
		public long? PublisherId { get; set; }

		public virtual Author Author { get; set; }
		public long AuthorId { get; set; }

		public virtual ICollection<Tag> Tags { get; set; }
	}
}
