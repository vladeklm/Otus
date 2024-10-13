using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PromoCodeFactory.Core.Domain.Administration
{
    public class Role
        : BaseEntity
    {
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        
        public List<Employee> Employees { get; set; }
    }
}