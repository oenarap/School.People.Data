using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class VerificationDetailsRepository : Repository<IVerificationDetails, PeopleDbContext>, IVerificationDetailsRepository
    {
        public async Task<IVerificationDetails> ReadAsync(Guid id)
        {
            try
            {
                var details = await Context.VerificationDetails.Where(d => d.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(IVerificationDetails item)
        {
            try
            {
                var details = await Context.VerificationDetails.Where(d => d.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (details != null)
                {
                    details.CommunityTaxCertificateNumber = item.CommunityTaxCertificateNumber;
                    details.CommunityTaxCertificateIssuanceDate = item.CommunityTaxCertificateIssuanceDate;
                    details.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    details = new DbVerificationDetails()
                    {
                        Id = item.Id,
                        CommunityTaxCertificateNumber = item.CommunityTaxCertificateNumber,
                        CommunityTaxCertificateIssuanceDate = item.CommunityTaxCertificateIssuanceDate,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.VerificationDetails.AddAsync(details);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public VerificationDetailsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
