using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class DateOfBirthsRepository : Repository<IDateOfBirth, PeopleDbContext>, IDateOfBirthsRepository
    {
        public async Task<IDateOfBirth> ReadAsync(Guid id)
        {
            try
            {
                var dob = await Context.DateOfBirths.Where(d => d.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return dob;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<bool> UpdateAsync(IDateOfBirth item)
        {
            try
            {
                var dob = await Context.DateOfBirths.Where(d => d.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (dob != null)
                {
                    dob.Birthdate = item.Birthdate;
                    dob.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    dob = new DbDateOfBirth()
                    {
                        Id = item.Id,
                        Birthdate = item.Birthdate,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.DateOfBirths.AddAsync(dob);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch
            {
                // TODO: log exception
                return false;
            }
        }

        public DateOfBirthsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
