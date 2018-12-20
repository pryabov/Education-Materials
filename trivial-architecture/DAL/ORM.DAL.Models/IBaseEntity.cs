﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.DAL.Models
{
	public interface IBaseEntity<T>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		T Id { get; set; }
	}
}
