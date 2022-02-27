using System.Linq;

namespace TrivialArchitecture.DAL.Repositories.Interfaces
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();

		T GetById(long id);

		void Create(T entity);

		void Update(T entity);

		bool Delete(long id);

		void Delete(T entity);
	}
}
