using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class FamilyIdsRepository : Repository<IFamilyIds, PeopleDbContext>, IFamilyIdsRepository
    {
        public async Task<IFamilyIds> ReadAsync(Guid id)
        {
            try
            {
                var ids = await Context.FamilyIds.Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return ids;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public FamilyIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
