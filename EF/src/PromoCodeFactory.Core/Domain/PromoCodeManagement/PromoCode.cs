﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode
        : BaseEntity
    {
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(150)]
        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
        
        [MaxLength(75)]
        public string PartnerName { get; set; }

        public Employee PartnerManager { get; set; }
        public Guid PartnerId { get; set; }

        public Preference Preference { get; set; }
        public Guid PreferenceId { get; set; }
        
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}