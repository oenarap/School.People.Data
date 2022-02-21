using Microsoft.EntityFrameworkCore;
using School.People.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.People.Data.Repositories
{
    public class ChildrenIdsRepository : Repository<Guid, PeopleDbContext>, IChildrenIdsRepository
    {
        public async Task<IEnumerable<Guid>> ReadAllAsync(Guid id)
        {
            try
            {
                return await Context.FamilyIds.AsNoTracking()
                    .Where(ids => ids.MotherId == id || ids.FatherId == id)
                    .Select(ids => ids.Id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ChildrenIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
