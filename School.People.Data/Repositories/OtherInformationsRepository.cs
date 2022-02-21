using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class OtherInformationsRepository : Repository<IOtherInformation, PeopleDbContext>, IOtherInformationsRepository
    {
        public async Task<bool> UpdateAsync(IOtherInformation item)
        {
            try
            {
                var info = await Context.OtherInformations.Where(i => i.Index != item.Index && i.Id == item.Id && i.Category == item.Category
                            && i.DescriptiveName == item.DescriptiveName).FirstOrDefaultAsync().ConfigureAwait(false);
                if (info == null)
                {
                    info = await Context.OtherInformations.Where(i => i.Index == item.Index && i.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (info != null)
                    {
                        info.Category = item.Category;
                        info.DescriptiveName = item.DescriptiveName;
                        info.Details = item.Details;
                        info.LastModifiedOn = DateTimeOffset.Now;
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

        public async Task<IOtherInformation> ReadAsync(Guid id)
        {
            try
            {
                return await Context.OtherInformations.AsNoTracking()
                    .Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteAsync(IOtherInformation item)
        {
            try
            {
                var info = await Context.OtherInformations.Where(i => i.Index == item.Index && i.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (info != null)
                {
                    Context.OtherInformations.Remove(info);
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(IOtherInformation item)
        {
            try
            {
                var info = await Context.OtherInformations.Where(i => i.Category == item.Category
                            && i.DescriptiveName == item.DescriptiveName).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (info == null)
                {
                    info = new DbOtherInformation()
                    {
                        Id = Guid.NewGuid(),
                        Category = item.Category,
                        DescriptiveName = item.DescriptiveName,
                        Details = item.Details,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.OtherInformations.AddAsync(info).ConfigureAwait(false);
                    if (await Context.SaveChangesAsync() > 0) { return info.Id; }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public OtherInformationsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
