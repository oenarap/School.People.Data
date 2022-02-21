using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class ContactDetailsRepository : Repository<IContactDetails, PeopleDbContext>, IContactDetailsRepository
    {
        public async Task<IContactDetails> ReadAsync(Guid id)
        {
            try
            {
                return await Context.ContactDetails.AsNoTracking()
                    .Where(d => d.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(IContactDetails item)
        {
            try
            {
                var details = await Context.ContactDetails.Where(d => d.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (details != null)
                {
                    details.MobileNumber = item.MobileNumber;
                    details.TelephoneNumber = item.TelephoneNumber;
                    details.EmailAddress = item.EmailAddress;
                    details.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    details = new DbContactDetails()
                    {
                        Id = item.Id,
                        MobileNumber = item.MobileNumber,
                        TelephoneNumber = item.TelephoneNumber,
                        EmailAddress = item.EmailAddress,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.ContactDetails.AddAsync(details);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ContactDetailsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
