using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Preference
        : BaseEntity
    {
        [MaxLength(75)]
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
    }
}