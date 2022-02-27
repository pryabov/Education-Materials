using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : class
	{
		protected DbContext DbContext { get; set; }

		protected DbSet<T> DbSet { get; set; }

		public BaseRepository(DbContext dbContext)
		{
			DbContext = dbContext ?? throw new ArgumentNullException("dbContext");
			DbSet = DbContext.Set<T>();
		}

		public virtual IQueryable<T> GetAll()
		{
			return DbSet;
		}

		public virtual T GetById(long id)
		{
			return DbSet.Find(id);
		}

		public virtual void Create(T entity)
		{
			EntityEntry dbEntityEntry = DbContext.Entry(entity);
			dbEntityEntry.State = EntityState.Added;
		}

		public virtual void Update(T entity)
		{
			EntityEntry dbEntityEntry = DbContext.Entry(entity);
			dbEntityEntry.State = EntityState.Modified;
		}

		public virtual bool Delete(long id)
		{
			T entity = GetById(id);
			if (entity != null)
			{
				Delete(entity);
				return true;
			}
			return false;
		}

		public void Delete(T entity)
		{
			EntityEntry dbEntityEntry = DbContext.Entry(entity);
			dbEntityEntry.State = EntityState.Deleted;
		}

		protected void RollBackChangesInContext()
		{
			List<EntityEntry> changedEntries = DbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
			foreach (EntityEntry entry in changedEntries.Where(x => x.State == EntityState.Modified))
			{
				entry.CurrentValues.SetValues(entry.OriginalValues);
				entry.State = EntityState.Unchanged;
			}

			foreach (EntityEntry entry in changedEntries.Where(x => x.State == EntityState.Added))
			{
				entry.State = EntityState.Detached;
			}

			foreach (EntityEntry entry in changedEntries.Where(x => x.State == EntityState.Deleted))
			{
				entry.State = EntityState.Unchanged;
			}
		}
	}
}
