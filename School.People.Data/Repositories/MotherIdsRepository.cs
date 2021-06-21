using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class MotherIdsRepository : Repository<Guid, PeopleDbContext>, IMotherIdsRepository
    {
        public async Task<bool> UpdateAsync(Guid key, Guid item)
        {
            try
            {
                var ids = await Context.FamilyIds.Where(i => i.Id == key).FirstOrDefaultAsync().ConfigureAwait(false);
                if (ids != null)
                {
                    ids.MotherId = item;
                    ids.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item != Guid.Empty)
                {
                    ids = new DbFamilyIds()
                    {
                        Id = key,
                        MotherId = item,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.FamilyIds.AddAsync(ids);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch
            {
                // TODO: log exception
                return false;
            }
        }

        public MotherIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
