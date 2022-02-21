using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class SpouseIdsRepository : Repository<Guid?, PeopleDbContext>, ISpouseIdsRepository
    {
        public async Task<bool> UpdateAsync(Guid key, Guid? item)
        {
            try
            {
                var ids = await Context.FamilyIds.Where(i => i.Id == key).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (ids != null)
                {
                    ids.SpouseId = item;
                    ids.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item != Guid.Empty)
                {
                    ids = new DbFamilyIds()
                    {
                        Id = key,
                        SpouseId = item,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.FamilyIds.AddAsync(ids);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public SpouseIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
