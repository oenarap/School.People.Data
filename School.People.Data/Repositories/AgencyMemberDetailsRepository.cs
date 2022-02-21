using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class AgencyMemberDetailsRepository : Repository<IAgencyMemberDetails, PeopleDbContext>, IAgencyMemberDetailsRepository
    {
        public async Task<IAgencyMemberDetails> ReadAsync(Guid id)
        {
            try
            {
                return await Context.AgencyMemberDetails.AsNoTracking()
                    .Where(d => d.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(IAgencyMemberDetails item)
        {
            try
            {
                var details = await Context.AgencyMemberDetails.Where(d => d.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (details != null)
                {
                    details.AgencyId = item.AgencyId;
                    details.GsisIdNumber = item.GsisIdNumber;
                    details.PagIbigIdNumber = item.PagIbigIdNumber;
                    details.PhilhealthNumber = item.PhilhealthNumber;
                    details.SssNumber = item.SssNumber;
                    details.Tin = item.Tin;
                    details.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    details = new DbAgencyMemberDetails()
                    {
                        Id = item.Id,
                        AgencyId = item.AgencyId,
                        GsisIdNumber = item.GsisIdNumber,
                        PagIbigIdNumber = item.PagIbigIdNumber,
                        PhilhealthNumber = item.PhilhealthNumber,
                        SssNumber = item.SssNumber,
                        Tin = item.Tin,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.AgencyMemberDetails.AddAsync(details);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public AgencyMemberDetailsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
