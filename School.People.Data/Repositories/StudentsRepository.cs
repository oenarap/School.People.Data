using System;
using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using School.People.Core.Repositories;

namespace School.People.Data.Repositories
{
    public class StudentsRepository : ActivePeopleRepository, IStudentsRepository
    {
        public async Task<IPerson> ReadAsync(Guid id)
        {
            try
            {
                return await Context.People.AsNoTracking()
                    .Where(p => p.Id == id && p.IsStudent == true)
                    .FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> ArchiveAsync(IPerson item)
        {
            try
            {
                var person = await Context.People.Where(p => p.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (person != null)
                {
                    person.IsStudent = false;
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<IEnumerable<IPerson>> ReadAllAsync()
        {
            try
            {
                return await Context.People.AsNoTracking()
                    .Where(p => p.IsStudent == true).ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Guid?> InsertAsync(IPerson item)
        {
            try
            {
                var person = await GetPersonByNameAsync(item).ConfigureAwait(false);
                
                if (person != null)
                {
                    person.IsStudent = true;
                    person.LastModifiedOn = DateTimeOffset.Now;
                }
                else
                {
                    person = new DbPerson()
                    {
                        Id = Guid.NewGuid(),
                        LastName = item.LastName,
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        NameExtension = item.NameExtension,
                        Title = item.Title,
                        IsStudent = true,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.People.AddAsync(person).ConfigureAwait(false);
                }
                if (await Context.SaveChangesAsync() > 0) { return person.Id; }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public StudentsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
