using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer
        : BaseEntity
    {
        [MaxLength(75)]
        public string FirstName { get; set; }
        
        [MaxLength(75)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [MaxLength(75)]
        public string Email { get; set; }
        public List<PromoCode> PromoCodes { get; set; }
        public List<Preference> Preferences { get; set; }
    }
}