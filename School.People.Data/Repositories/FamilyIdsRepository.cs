using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class FamilyIdsRepository : Repository<IFamilyIds, PeopleDbContext>, IFamilyIdsRepository
    {
        public async Task<IEnumerable<IFamilyIds>> ReadAllAsync(Guid id)
        {
            try
            {
                var ids = await Context.FamilyIds.Where(i => i.MotherId == id || i.FatherId == id).ToListAsync().ConfigureAwait(false);
                return ids;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<IFamilyIds> ReadAsync(Guid id)
        {
            try
            {
                var ids = await Context.FamilyIds.Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return ids;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public FamilyIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
