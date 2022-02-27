using System;
using System.Collections.Generic;
using System.Linq;
using TrivialArchitecture.DAL.Base;
using TrivialArchitecture.DAL.Base.Enums;
using TrivialArchitecture.DAL.Entities;
using TrivialArchitecture.DAL.Interfaces;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity<long>
	{
		protected DbContext DbContext { get; set; }

		protected DbSet<T> DbSet { get; set; }

		public BaseRepository(DbContext dbContext)
		{
			DbContext = dbContext ?? throw new ArgumentNullException("dbContext");
			DbSet = DbContext.Set<T>();
		}

		public virtual IList<T> GetAll()
		{
			return DbSet;
		}

		public T GetById(long id)
		{
			T entity = DbSet.SingleOrDefault(entity => entity.Id == id);
			return entity;
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
			T entity = DbSet.SingleOrDefault(entity => entity.Id == id);
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
	}
}
