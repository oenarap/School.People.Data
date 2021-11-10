using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Apps.DataClient.Core;

namespace School.People.Data.Repositories
{
    public class CivicWorksRepository : Repository<ICivicWork, PeopleDbContext>, ICivicWorksRepository
    {
        public async Task<bool> UpdateAsync(ICivicWork item)
        {
            try
            {
                var cwork = await Context.CivicWorks.Where(cw => cw.Index != item.Index && cw.Id == item.Id && cw.PositionTitle == item.PositionTitle
                            && cw.EmployerOrganizationOrBusinessName == item.EmployerOrganizationOrBusinessName)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (cwork == null)
                {
                    cwork = await Context.CivicWorks.Where(cw => cw.Index == item.Index && cw.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (cwork != null)
                    {
                        cwork.PositionTitle = item.PositionTitle;
                        cwork.EmployerOrganizationOrBusinessName = item.EmployerOrganizationOrBusinessName;
                        cwork.TelephoneNumber = item.TelephoneNumber;
                        cwork.StartDate = item.StartDate;
                        cwork.EndDate = item.EndDate;
                        cwork.IsOngoing = item.IsOngoing;
                        cwork.LocationAddressId = item.LocationAddressId;
                        cwork.TotalHoursWorked = item.TotalHoursWorked;
                        cwork.LastModifiedOn = DateTimeOffset.Now;
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

        public async Task<ICivicWork> ReadAsync(Guid id)
        {
            try
            {
                var cworks = await Context.CivicWorks.Where(cw => cw.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return cworks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteAsync(ICivicWork item)
        {
            try
            {
                DbCivicWork cwork = await Context.CivicWorks.Where(cw => cw.Index == item.Index && cw.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (cwork != null)
                {
                    Context.CivicWorks.Remove(cwork);
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(ICivicWork item)
        {
            try
            {
                var cwork = await Context.CivicWorks.Where(cw => cw.PositionTitle == item.PositionTitle
                            && cw.EmployerOrganizationOrBusinessName == item.EmployerOrganizationOrBusinessName)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (cwork == null)
                {
                    cwork = new DbCivicWork()
                    {
                        Id = Guid.NewGuid(),
                        PositionTitle = item.PositionTitle,
                        EmployerOrganizationOrBusinessName = item.EmployerOrganizationOrBusinessName,
                        TelephoneNumber = item.TelephoneNumber,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IsOngoing = item.IsOngoing,
                        LocationAddressId = item.LocationAddressId,
                        TotalHoursWorked = item.TotalHoursWorked,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.CivicWorks.AddAsync(cwork).ConfigureAwait(false);
                    if (await Context.SaveChangesAsync() > 0) { return cwork.Id; }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public CivicWorksRepository(PeopleDbContext context)
            : base(context) { }
    }
}
