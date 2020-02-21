using Mastery.Example.BLL.Common.Models.Customer;
using Mastery.Example.DAL.Common.Models.Customer;

namespace Mastery.Example.BLL.Converter.Customer
{
    public class ConvertRequestModel
    {
        public static CustomerDbModel ToDbModel(CustomerRequestModel model)
            => new CustomerDbModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Age = model.Age
            };
    }
}
