using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureUow : ITrivialArchitectureUow
	{
		private readonly DbContext dbContext;
		private readonly IServiceProvider serviceProvider;

		public TrivialArchitectureUow(IServiceProvider serviceProvider, DbContext dbContext)
		{
			this.dbContext = dbContext;
			this.serviceProvider = serviceProvider;
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
			T repository = serviceProvider.GetService<T>();
			return repository;
		}
	}
}
