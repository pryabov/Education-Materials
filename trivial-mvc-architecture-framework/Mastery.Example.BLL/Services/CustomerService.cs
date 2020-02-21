using System.Collections.Generic;
using System.Linq;
using Mastery.Example.BLL.Common.Interfaces;
using Mastery.Example.BLL.Common.Models.Customer;
using Mastery.Example.BLL.Converter.Customer;
using Mastery.Example.DAL.Common.Interfaces;
using Mastery.Example.DAL.Common.Models.Customer;

namespace Mastery.Example.BLL.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IGenericRepository<CustomerDbModel> customerGenericRepository;

        public CustomerService(IUnitOfWork unitOfWork) : base()
        {
            this.unitOfWork = unitOfWork;
            customerGenericRepository = unitOfWork.GetGenericRepository<CustomerDbModel>();
        }

        public IEnumerable<CustomerViewModel> GetCustomers() =>
            customerGenericRepository
                .GetQueryAsNoTracking()
                .AsEnumerable()
                .Select(ConvertDbModel.ToViewModel);

        public CustomerViewModel CreateCustomers(CustomerRequestModel customer)
        {
            var customerDbModel = ConvertRequestModel.ToDbModel(customer);

            customerGenericRepository.Add(customerDbModel);
            unitOfWork.SaveChanges();

            return ConvertDbModel.ToViewModel(customerDbModel);
        }
    }
}
