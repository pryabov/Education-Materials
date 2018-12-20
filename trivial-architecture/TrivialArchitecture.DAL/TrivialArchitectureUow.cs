using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Autofac;
using TrivialArchitecture.DAL.Interfaces;
using TrivialArchitecture.DAL.Interfaces.CustomRepositories;
using TrivialArchitecture.DAL.Models.Entities.Cars;

namespace TrivialArchitecture.DAL
{
	public class TrivialArchitectureUow : ITrivialArchitectureUow
	{
		private readonly DbContext _dbContext;
		private readonly ILifetimeScope _lifetimeScope;

		public TrivialArchitectureUow(ILifetimeScope lifetimeScope, DbContext dbContext)
		{
			_dbContext = dbContext;
			_lifetimeScope = lifetimeScope;
		}

		#region Repositories

		#region MsSQL

		public ICarDriversRepository CarDrivers => GetRepository<ICarDriversRepository>();

		public IRepository<Car> Cars => GetRepository<IRepository<Car>>();

		#endregion MsSQL

		#endregion

		/// <summary>
		/// Save pending changes to the database
		/// </summary>
		public void Commit()
		{
			try
			{
				_dbContext.SaveChanges();
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
			T repository = _lifetimeScope.Resolve<T>();
			return repository;
		}
	}
}
