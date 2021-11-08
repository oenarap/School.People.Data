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
                var result = await (from ids in Context.FamilyIds
                             where (ids.FatherId == id || ids.MotherId == id)
                             select ids.Id).ToListAsync();
                return result;
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
