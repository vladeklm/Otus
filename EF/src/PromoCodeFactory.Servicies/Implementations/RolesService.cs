using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Servicies.Abstractions;
using PromoCodeFactory.Servicies.DataTransferObjects;

namespace PromoCodeFactory.Servicies.Implementations;

public class RolesService: IRolesService
{
    private readonly IRepository<Role> _rolesRepository;

    public RolesService(IRepository<Role> rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }
    
    public async Task<IEnumerable<RoleItemDto>> GetRolesAsync(CancellationToken token)
    {
        var roles = await _rolesRepository.GetAllAsync(token);

        var rolesModelList = roles.Select(x =>
            new RoleItemDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

        return rolesModelList;
    }
}