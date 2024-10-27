using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Servicies.Abstractions;
using PromoCodeFactory.Servicies.DataTransferObjects;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Роли сотрудников
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RolesController
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        /// <summary>
        /// Получить все доступные роли сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<RoleItemDto>> GetRolesAsync()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;
            return await _rolesService.GetRolesAsync(token);
        }
    }
}