using KonsolApplikationEFC.Contexts;
using KonsolApplikationEFC.Entities;

namespace KonsolApplikationEFC.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
