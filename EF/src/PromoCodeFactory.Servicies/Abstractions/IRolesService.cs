using PromoCodeFactory.Servicies.DataTransferObjects;

namespace PromoCodeFactory.Servicies.Abstractions;

public interface IRolesService
{
    public Task<IEnumerable<RoleItemDto>> GetRolesAsync(CancellationToken token);
}