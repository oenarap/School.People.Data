using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class EducationsRepository : Repository<IEducation, PeopleDbContext>, IEducationsRepository
    {
        public async Task<bool> UpdateAsync(IEducation item)
        {
            try
            {
                var educ = await Context.Educations.Where(e => e.Index != item.Index && e.Id == item.Id && e.Level == item.Level
                            && e.SchoolName == item.SchoolName && e.DegreeCourse == item.DegreeCourse)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (educ == null)
                {
                    educ = await Context.Educations.Where(e => e.Index == item.Index && e.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (educ != null)
                    {
                        educ.Level = item.Level;
                        educ.DegreeCourse = item.DegreeCourse;
                        educ.SchoolName = item.SchoolName;
                        educ.IfGraduatedYearGraduated = item.IfGraduatedYearGraduated;
                        educ.IfNotGraduatedHighestLevelOrUnitsEarned = item.IfNotGraduatedHighestLevelOrUnitsEarned;
                        educ.StartDate = item.StartDate;
                        educ.EndDate = item.EndDate;
                        educ.ScholarshipOrHonorsReceived = item.ScholarshipOrHonorsReceived;
                        educ.IsOngoing = item.IsOngoing;
                        educ.LastModifiedOn = DateTimeOffset.Now;
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

        public async Task<IEnumerable<IEducation>> ReadAsync(Guid id)
        {
            try
            {
                IEnumerable<DbEducation> educs = await Context.Educations.Where(e => e.Id == id).ToListAsync().ConfigureAwait(false);
                return educs;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<bool> DeleteAsync(IEducation item)
        {
            try
            {
                DbEducation educ = await Context.Educations.Where(e => e.Index == item.Index && e.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (educ != null)
                {
                    Context.Educations.Remove(educ);
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

        public async Task<Guid?> InsertAsync(IEducation item, Guid key)
        {
            try
            {
                var educ = await Context.Educations.Where(e => e.Id == key && e.Level == item.Level
                            && e.SchoolName == item.SchoolName && e.DegreeCourse == item.DegreeCourse)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (educ == null)
                {
                    educ = new DbEducation()
                    {
                        Id = key,
                        Index = Guid.NewGuid(),
                        Level = item.Level,
                        SchoolName = item.SchoolName,
                        DegreeCourse = item.DegreeCourse,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IfGraduatedYearGraduated = item.IfGraduatedYearGraduated,
                        IfNotGraduatedHighestLevelOrUnitsEarned = item.IfNotGraduatedHighestLevelOrUnitsEarned,
                        ScholarshipOrHonorsReceived = item.ScholarshipOrHonorsReceived,
                        IsOngoing = item.IsOngoing,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Educations.AddAsync(educ).ConfigureAwait(false);
                    if (await Context.SaveChangesAsync() > 0) { return educ.Index; }
                }
                return null;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public EducationsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
