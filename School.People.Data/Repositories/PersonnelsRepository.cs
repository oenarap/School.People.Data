using System;
using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class PersonnelsRepository : ActivePeopleRepository, IPersonnelRepository
    {
        public async Task<IPerson> ReadAsync(Guid id)
        {
            try
            {
                DbPerson person = await Context.People.Where(p => p.Id == id && p.IsPersonnel == true).FirstOrDefaultAsync().ConfigureAwait(false);
                return person;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<bool> ArchiveAsync(IPerson item)
        {
            try
            {
                DbPerson person = await Context.People.Where(p => p.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (person != null)
                {
                    person.IsPersonnel = false;
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

        public async Task<IEnumerable<IPerson>> ReadAllAsync()
        {
            try
            {
                IEnumerable<DbPerson> people = await Context.People.Where(p => p.IsPersonnel == true).ToListAsync().ConfigureAwait(false);
                return people;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<Guid?> InsertAsync(IPerson item)
        {
            try
            {
                DbPerson person = await GetPersonByNameAsync(item).ConfigureAwait(false);
                if (person != null)
                {
                    person.IsPersonnel = true;
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
                        NameExtension = FixNameExtension(item.NameExtension),
                        Title = item.Title,
                        IsPersonnel = true,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.People.AddAsync(person).ConfigureAwait(false);
                }
                if (await Context.SaveChangesAsync() > 0) { return person.Id; }
                return null;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public PersonnelsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
