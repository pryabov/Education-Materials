using System.Collections.Generic;

namespace TrivialArchitecture.DAL.Repositories.Interfaces
{
	public interface IRepository<T> where T : class
	{
		IList<T> GetAll();

		T GetById(long id);

		void Create(T entity);

		void Update(T entity);

		bool Delete(long id);

		void Delete(T entity);
	}
}
