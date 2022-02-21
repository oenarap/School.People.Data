using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class EligibilitiesRepository : Repository<IEligibility, PeopleDbContext>, IEligibilitiesRepository
    {
        public async Task<bool> UpdateAsync(IEligibility item)
        {
            try
            {
                var eligibility = await Context.Eligibilities.Where(e => e.Index != item.Index && e.Id == item.Id &&
                                            e.EligibilityName == item.EligibilityName).FirstOrDefaultAsync().ConfigureAwait(false);
                if (eligibility == null)
                {
                    eligibility = await Context.Eligibilities.Where(e => e.Index == item.Index && e.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    
                    if (eligibility != null)
                    {
                        eligibility.EligibilityName = item.EligibilityName;
                        eligibility.Rating = item.Rating;
                        eligibility.DateOfExamOrConferment = item.DateOfExamOrConferment;
                        eligibility.LicenseDateOfRelease = item.LicenseDateOfRelease;
                        eligibility.LicenseNumberIfApplicable = item.LicenseNumberIfApplicable;
                        eligibility.PlaceOfExamConferment = item.PlaceOfExamConferment;
                        eligibility.LastModifiedOn = DateTimeOffset.Now;
                        return await Context.SaveChangesAsync() > 0;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<IEligibility> ReadAsync(Guid id)
        {
            try
            {
                return await Context.Eligibilities.AsNoTracking()
                    .Where(e => e.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteAsync(IEligibility item)
        {
            try
            {
                var eligibility = await Context.Eligibilities.Where(e => e.Index == item.Index && e.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (eligibility != null)
                {
                    Context.Eligibilities.Remove(eligibility);
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(IEligibility item)
        {
            try
            {
                var eligibility = await Context.Eligibilities.Where(e => e.EligibilityName == item.EligibilityName).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (eligibility == null)
                {
                    eligibility = new DbEligibility()
                    {
                        Id = Guid.NewGuid(),
                        EligibilityName = item.EligibilityName,
                        Rating = item.Rating,
                        DateOfExamOrConferment = item.DateOfExamOrConferment,
                        LicenseDateOfRelease = item.LicenseDateOfRelease,
                        LicenseNumberIfApplicable = item.LicenseNumberIfApplicable,
                        PlaceOfExamConferment = item.PlaceOfExamConferment,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Eligibilities.AddAsync(eligibility).ConfigureAwait(false);
                    if (await Context.SaveChangesAsync() > 0) { return eligibility.Id; }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public EligibilitiesRepository(PeopleDbContext context)
            : base(context) { }
    }
}
