using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class PersonDetailsRepository : Repository<IPersonDetails, PeopleDbContext>, IPersonDetailsRepository
    {
        public async Task<IPersonDetails> ReadAsync(Guid id)
        {
            try
            {
                var details = await Context.PersonDetails.Where(d => d.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(IPersonDetails item)
        {
            try
            {
                var details = await Context.PersonDetails.Where(pd => pd.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (details != null)
                {
                    details.BloodType = item.BloodType;
                    details.CivilStatus = item.CivilStatus;
                    details.HeightInCentimeters = item.HeightInCentimeters;
                    details.OtherCivilStatus = item.OtherCivilStatus;
                    details.Sex = item.Sex;
                    details.WeightInKilograms = item.WeightInKilograms;
                    details.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    details = new DbPersonDetails()
                    {
                        Id = item.Id,
                        BloodType = item.BloodType,
                        CivilStatus = item.CivilStatus,
                        HeightInCentimeters = item.HeightInCentimeters,
                        OtherCivilStatus = item.OtherCivilStatus,
                        Sex = item.Sex,
                        WeightInKilograms = item.WeightInKilograms,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.PersonDetails.AddAsync(details);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public PersonDetailsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
