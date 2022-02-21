using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class TrainingsRepository : Repository<ITraining, PeopleDbContext>, ITrainingsRepository
    {
        public async Task<bool> UpdateAsync(ITraining item)
        {
            try
            {
                var training = await Context.Trainings.Where(t => t.Index != item.Index && t.Id == item.Id && t.TitleOfTrainingProgram == item.TitleOfTrainingProgram
                            && t.Sponsor == item.Sponsor).FirstOrDefaultAsync().ConfigureAwait(false);
                if (training == null)
                {
                    training = await Context.Trainings.Where(t => t.Index == item.Index && t.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (training != null)
                    {
                        training.TitleOfTrainingProgram = item.TitleOfTrainingProgram;
                        training.Sponsor = item.Sponsor;
                        training.StartDate = item.StartDate;
                        training.EndDate = item.EndDate;
                        training.IsOngoing = item.IsOngoing;
                        training.LocationAddressId = item.LocationAddressId;
                        training.DurationHours = item.DurationHours;
                        training.LastModifiedOn = DateTimeOffset.Now;
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

        public async Task<ITraining> ReadAsync(Guid id)
        {
            try
            {
                return await Context.Trainings.AsNoTracking()
                    .Where(t => t.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> DeleteAsync(ITraining item)
        {
            try
            {
                DbTraining training = await Context.Trainings.Where(t => t.Index == item.Index && t.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (training != null)
                {
                    Context.Trainings.Remove(training);
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(ITraining item)
        {
            try
            {
                var training = await Context.Trainings.Where(t => t.TitleOfTrainingProgram == item.TitleOfTrainingProgram
                                && t.Sponsor == item.Sponsor).FirstOrDefaultAsync().ConfigureAwait(false);
                if (training == null)
                {
                    training = new DbTraining()
                    {
                        Id = Guid.NewGuid(),
                        TitleOfTrainingProgram = item.TitleOfTrainingProgram,
                        Sponsor = item.Sponsor,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        IsOngoing = item.IsOngoing,
                        LocationAddressId = item.LocationAddressId,
                        DurationHours = item.DurationHours,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Trainings.AddAsync(training).ConfigureAwait(false);
                    if (await Context.SaveChangesAsync() > 0) { return training.Id; }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public TrainingsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
