using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mastery.Example.DAL.Common.Models.Customer;

namespace Mastery.Example.DAL.Common.Models.Product
{
    public class ProductDbModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public List<CustomerDbModel> Customers { get; set; }
    }
}
