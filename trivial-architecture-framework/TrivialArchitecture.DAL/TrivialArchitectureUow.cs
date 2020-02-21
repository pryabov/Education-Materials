using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Autofac;
using TrivialArchitecture.DAL.Repositories.Interfaces;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureUow : ITrivialArchitectureUow
	{
		private readonly DbContext dbContext;
		private readonly ILifetimeScope lifetimeScope;

		public TrivialArchitectureUow(ILifetimeScope lifetimeScope, DbContext dbContext)
		{
			this.dbContext = dbContext;
			this.lifetimeScope = lifetimeScope;
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
			catch (DbEntityValidationException e)
			{
				foreach (DbEntityValidationResult validationErrors in e.EntityValidationErrors)
				{
					foreach (DbValidationError validationError in validationErrors.ValidationErrors)
					{
						string errorMessage =
							$"DB validation error. Property name: '{validationError.PropertyName}'. Error message: {validationError.ErrorMessage}";
					}
				}
				throw;
			}
			catch (Exception e)
			{
				//TODO: Log Error
				throw;
			}
		}

		private T GetRepository<T>() where T : class
		{
			T repository = lifetimeScope.Resolve<T>();
			return repository;
		}
	}
}
