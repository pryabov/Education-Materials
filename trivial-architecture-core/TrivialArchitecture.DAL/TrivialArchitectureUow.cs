using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureUow : ITrivialArchitectureUow
	{
		private readonly DbContext dbContext;
		private readonly ILifetimeScope container;

		public TrivialArchitectureUow(ILifetimeScope container, DbContext dbContext)
		{
			this.dbContext = dbContext;
			this.container = container;
		}

		#region Repositories

		#region MsSQL

		public ICarDriversRepository CarDrivers => GetRepository<ICarDriversRepository>();

		public ICarsRepository Cars => GetRepository<ICarsRepository>();

		#endregion MsSQL

		#endregion

		/// <summary>
		/// Save pending changes to the database
		/// </summary>
		public void Commit()
		{
			try
			{
				dbContext.SaveChanges();
			}
			catch (Exception)
			{
				//TODO: Log Error
				throw;
			}
		}

		private T GetRepository<T>() where T : class
		{
			T repository = container.Resolve<T>();
			return repository;
		}
	}
}
