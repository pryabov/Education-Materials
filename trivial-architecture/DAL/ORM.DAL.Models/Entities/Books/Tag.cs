using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.DAL.Models.Entities
{
	[Table("Tags")]
	public class Tag : IBaseEntity<long>
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<Book> Books { get; set; }
	}
}
