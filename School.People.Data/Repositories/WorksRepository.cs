using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class WorksRepository : Repository<IWork, PeopleDbContext>, IWorksRepository
    {
        public async Task<bool> UpdateAsync(IWork item)
        {
            try
            {
                var work = await Context.Works.Where(w => w.Index != item.Index && w.Id == item.Id && w.PositionTitle == item.PositionTitle
                            && w.EmployerOrganizationOrBusinessName == item.EmployerOrganizationOrBusinessName)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (work == null)
                {
                    work = await Context.Works.Where(w => w.Index == item.Index && w.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (work != null)
                    {
                        work.PositionTitle = item.PositionTitle;
                        work.EmployerOrganizationOrBusinessName = item.EmployerOrganizationOrBusinessName;
                        work.TelephoneNumber = item.TelephoneNumber;
                        work.MonthlySalary = item.MonthlySalary;
                        work.StatusOfAppointment = item.StatusOfAppointment;
                        work.SalaryGradeAndStepIncrement = item.SalaryGradeAndStepIncrement;
                        work.IsGovernmentService = item.IsGovernmentService;
                        work.StartDate = item.StartDate;
                        work.EndDate = item.EndDate;
                        work.IsOngoing = item.IsOngoing;
                        work.LocationAddressId = item.LocationAddressId;
                        work.LastModifiedOn = DateTimeOffset.Now;
                        return await Context.SaveChangesAsync() > 0;
                    }
                }
                return false;
            }
            catch
            {
                // TODO: log exception
                return false;
            }
        }

        public async Task<IEnumerable<IWork>> ReadAsync(Guid id)
        {
            try
            {
                IEnumerable<DbWork> works = await Context.Works.Where(w => w.Id == id).ToListAsync().ConfigureAwait(false);
                return works;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<bool> DeleteAsync(IWork item)
        {
            try
            {
                DbWork work = await Context.Works.Where(w => w.Index == item.Index && w.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (work != null)
                {
                    Context.Works.Remove(work);
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch
            {
                // TODO: log exception
                return false;
            }
        }

        public async Task<Guid?> InsertAsync(IWork item, Guid key)
        {
            try
            {
                var work = await Context.Works.Where(w => w.Id == key && w.PositionTitle == item.PositionTitle
                            && w.EmployerOrganizationOrBusinessName == item.EmployerOrganizationOrBusinessName)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (work == null)
                {
                    work = new DbWork()
                    {
                        Id = key,
                        Index = Guid.NewGuid(),
                        PositionTitle = item.PositionTitle,
                        EmployerOrganizationOrBusinessName = item.EmployerOrganizationOrBusinessName,
                        TelephoneNumber = item.TelephoneNumber,
                        MonthlySalary = item.MonthlySalary,
                        StatusOfAppointment = item.StatusOfAppointment,
                        SalaryGradeAndStepIncrement = item.SalaryGradeAndStepIncrement,
                        IsGovernmentService = item.IsGovernmentService,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IsOngoing = item.IsOngoing,
                        LocationAddressId = item.LocationAddressId,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Works.AddAsync(work).ConfigureAwait(false);
                    if (await Context.SaveChangesAsync() > 0) { return work.Index; }
                }
                return null;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public WorksRepository(PeopleDbContext context)
            : base(context) { }
    }
}
