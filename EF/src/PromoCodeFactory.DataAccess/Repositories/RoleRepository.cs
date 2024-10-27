using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.DataAccess.Repositories;

public class RoleRepository:EfRepository<Role>
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}