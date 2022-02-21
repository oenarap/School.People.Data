using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class CitizenshipsRepository : Repository<ICitizenship, PeopleDbContext>, ICitizenshipsRepository
    {
        public async Task<ICitizenship> ReadAsync(Guid id)
        {
            try
            {
                return await Context.Citizenships.AsNoTracking()
                    .Where(c => c.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(ICitizenship item)
        {
            try
            {
                var citizenship = await Context.Citizenships.Where(c => c.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (citizenship != null)
                {
                    citizenship.DualCitizenshipMode = item.DualCitizenshipMode;
                    citizenship.DualCitizenship = item.DualCitizenship;
                    citizenship.Country = item.Country;
                    citizenship.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    citizenship = new DbCitizenship()
                    {
                        Id = item.Id,
                        DualCitizenshipMode = item.DualCitizenshipMode,
                        DualCitizenship = item.DualCitizenship,
                        Country = item.Country,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Citizenships.AddAsync(citizenship);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public CitizenshipsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
