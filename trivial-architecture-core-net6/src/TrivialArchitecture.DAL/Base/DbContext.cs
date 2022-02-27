using System;
using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.DAL.Base.Enums;
using TrivialArchitecture.DAL.Entities;

namespace TrivialArchitecture.DAL.Base
{
	public class DbContext
	{
		private readonly Dictionary<Type, List<EntityEntry>> state = new();

		public bool IsLoaded { get; protected set; }

		public DbSet<T> Set<T>() where T : class, IBaseEntity<long>
		{
			DbSet<T> result = new DbSet<T>(this);
			return result;
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

		public void Load()
		{
			if (!IsLoaded)
			{
				// TODO: Load from file
			}
		}

		public void SaveChanges()
		{
			foreach (KeyValuePair<Type, List<EntityEntry>> keyValuePair in state)
			{
				List<EntityEntry> changedEntities =
					keyValuePair.Value.Where(entity => entity.State
						is EntityState.Added
						or EntityState.Deleted
						or EntityState.Modified).ToList();

				if (changedEntities.Count > 0)
				{
					// TODO: Save
				}
			}
		}
	}
}
