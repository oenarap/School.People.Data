using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class AddressIdsRepository : Repository<IAddressIds, PeopleDbContext>, IAddressIdsRepository
    {
        public async Task<IAddressIds> ReadAsync(Guid id)
        {
            try
            {
                var ids = await Context.AddressIds.Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return ids;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<bool> UpdateAsync(IAddressIds item)
        {
            try
            {
                var ids = await Context.AddressIds.Where(i => i.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (ids != null)
                {
                    ids.ResidentialAddressId = item.ResidentialAddressId;
                    ids.PermanentAddressId = item.PermanentAddressId;
                    ids.BusinessAddressId = item.BusinessAddressId;
                    ids.BirthAddressId = item.BirthAddressId;
                    ids.CommunityTaxCertificateIssuanceAddressId = item.CommunityTaxCertificateIssuanceAddressId;
                    ids.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    ids = new DbAddressIds()
                    {
                        Id = item.Id,
                        PermanentAddressId = item.PermanentAddressId,
                        ResidentialAddressId = item.ResidentialAddressId,
                        BusinessAddressId = item.BusinessAddressId,
                        BirthAddressId = item.BirthAddressId,
                        CommunityTaxCertificateIssuanceAddressId = item.CommunityTaxCertificateIssuanceAddressId,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.AddressIds.AddAsync(ids);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch
            {
                // TODO: log exception
                return false;
            }
        }

        public AddressIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
