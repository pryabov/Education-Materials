using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialArchitecture.DAL.Base;

namespace TrivialArchitecture.DAL.Interfaces
{
	public class DbContext
	{
		private Dictionary<Type, List<EntityEntry>> state = new();

		public DbSet<T> Set<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public EntityEntry Entry<T>(T entity) where T : class
		{
			if (state.TryGetValue(typeof(T), out List<EntityEntry> entities))
			{
				EntityEntry entityEntry = entities.SingleOrDefault(item => item.Entity.Equals(entity));

				if (entityEntry != null)
				{
					return entityEntry;
				}

				throw new KeyNotFoundException();
			}

			throw new KeyNotFoundException();
		}
	}
}
