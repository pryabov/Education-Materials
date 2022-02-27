using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.DAL.Base.Enums;
using TrivialArchitecture.DAL.Entities;

namespace TrivialArchitecture.DAL.Base
{
	public class DbSet<T> : IList<T> where T : class, IBaseEntity<long>
	{
		private readonly DbContext dbContext;
		private List<EntityEntry> entityEntries;
		private List<T> entities;

		public DbSet(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		#region IList{T}

		public IEnumerator<T> GetEnumerator()
		{
			LoadEntitiesIfNeeded();

			return entities.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			LoadEntitiesIfNeeded();

			return entities.GetEnumerator();
		}

		public void Add(T item)
		{
			LoadEntitiesIfNeeded();

			entities.Add(item);
			entityEntries.Add(new EntityEntry()
			{
				Entity = item,
				EntityType = typeof(T),
				State = EntityState.Added
			});
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(T item)
		{
			LoadEntitiesIfNeeded();

			entities.Remove(item);
			int index = entityEntries.FindIndex(entryEntity => entryEntity.Entity == item);
			if (index > 0)
			{
				entityEntries[index].State = EntityState.Deleted;
				return true;
			}

			return false;
		}

		public int Count => entities.Count;
		public bool IsReadOnly => false;

		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public T this[int index]
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		#endregion

		private void LoadEntitiesIfNeeded()
		{
			if (entityEntries != null)
			{
				entityEntries = dbContext.GetState(typeof(T));
				entities = entityEntries.Select(item => item.Entity as T).ToList();
			}
		}
	}
}
