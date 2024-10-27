using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Employee
        : BaseEntity
    {
        [MaxLength(75)]
        public string FirstName { get; set; }
        
        [MaxLength(75)]
        public string LastName { get; set; }

        //public string FullName => $"{FirstName} {LastName}";

        [MaxLength(75)]
        public string Email { get; set; }

        public Role Role { get; set; }
        public Guid RoleId { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}