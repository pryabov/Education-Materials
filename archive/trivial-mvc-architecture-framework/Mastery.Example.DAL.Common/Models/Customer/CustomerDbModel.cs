using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mastery.Example.DAL.Common.Models.Product;

namespace Mastery.Example.DAL.Common.Models.Customer
{
    public class CustomerDbModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public byte[] Photo { get; set; }

        public List<ProductDbModel> Products { get; set; }
    }
}