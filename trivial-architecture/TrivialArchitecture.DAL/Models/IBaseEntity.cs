using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrivialArchitecture.DAL.Models
{
	public interface IBaseEntity<T>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		T Id { get; set; }
	}
}
