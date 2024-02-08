using KonsolApplikationEFC.Contexts;
using KonsolApplikationEFC.Entities;

namespace KonsolApplikationEFC.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}
