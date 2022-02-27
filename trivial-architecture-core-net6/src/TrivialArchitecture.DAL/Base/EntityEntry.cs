using System;
using TrivialArchitecture.DAL.Base.Enums;

namespace TrivialArchitecture.DAL.Base
{
	public class EntityEntry
	{
		public EntityState State { get; set; }

		public Type EntityType { get; set; }

		public object Entity { get; set; }
	}
}
