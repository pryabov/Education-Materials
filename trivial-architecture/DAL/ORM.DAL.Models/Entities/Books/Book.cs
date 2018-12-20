using System.Collections.Generic;
using ORM.DAL.Models.Enums;

namespace ORM.DAL.Models.Entities
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
