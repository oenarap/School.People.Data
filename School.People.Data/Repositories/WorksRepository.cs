using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<IWork> ReadAsync(Guid id)
        {
            try
            {
                return await Context.Works.AsNoTracking()
                    .Where(w => w.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteAsync(IWork item)
        {
            try
            {
                var work = await Context.Works.Where(w => w.Index == item.Index && w.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (work != null)
                {
                    Context.Works.Remove(work);
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(IWork item)
        {
            try
            {
                var work = await Context.Works.Where(w => w.PositionTitle == item.PositionTitle
                            && w.EmployerOrganizationOrBusinessName == item.EmployerOrganizationOrBusinessName)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (work == null)
                {
                    work = new DbWork()
                    {
                        Id = Guid.NewGuid(),
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
                    if (await Context.SaveChangesAsync() > 0) { return work.Id; }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public WorksRepository(PeopleDbContext context)
            : base(context) { }
    }
}
