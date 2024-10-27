using System;
using PromoCodeFactory.Servicies.DataTransferObjects;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public RoleItemDto Role { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}