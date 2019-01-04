using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialArchitecture.DAL.Models.Entities.Cars;

namespace TrivialArchitecture.DAL.Interfaces.CustomRepositories
{
	public interface ICarsRepository : IRepository<Car>
	{
		Car GetByNumber(string number);
	}
}
