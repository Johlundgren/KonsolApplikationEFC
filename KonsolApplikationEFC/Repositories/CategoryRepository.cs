using KonsolApplikationEFC.Contexts;
using KonsolApplikationEFC.Entities;

namespace KonsolApplikationEFC.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
