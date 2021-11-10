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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<IEducation> ReadAsync(Guid id)
        {
            try
            {
                var educ = await Context.Educations.Where(e => e.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return educ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(IEducation item)
        {
            try
            {
                var educ = await Context.Educations.Where(e => e.Level == item.Level
                            && e.SchoolName == item.SchoolName && e.DegreeCourse == item.DegreeCourse)
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                if (educ == null)
                {
                    educ = new DbEducation()
                    {
                        Id = Guid.NewGuid(),
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
                    if (await Context.SaveChangesAsync() > 0) { return educ.Id; }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public EducationsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
