using System;
using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class OtherPeopleRepository : PeopleRepository, IOtherPeopleRepository
    {
        public async Task<bool> UpdateAsync(IPerson item)
        {
            try
            {
                var person = await GetPersonByNameAsync(item).ConfigureAwait(false);
                
                if (person == null)
                {
                    person = await Context.People.Where(p => p.Id == item.Id && p.IsPersonnel == false &&
                        p.IsStudent == false && p.IsOther == true).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (person != null)
                    {
                        person.LastName = item.LastName;
                        person.FirstName = item.FirstName;
                        person.MiddleName = item.MiddleName;
                        person.NameExtension = FixNameExtension(item.NameExtension);
                        person.Title = item.Title;
                        return await Context.SaveChangesAsync() > 0;
                    }
                }
                else if (person.Id == item.Id)
                {
                    person.Title = item.Title;
                    return await Context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<IPerson> ReadAsync(Guid id)
        {
            try
            {
                var person = await Context.People.Where(p => p.Id == id && p.IsPersonnel == false &&
                        p.IsStudent == false && p.IsOther == true).FirstOrDefaultAsync().ConfigureAwait(false);
                return person;
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
                    person.IsOther = false;
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
                var people = await Context.People.Where(p => p.IsPersonnel == false &&
                    p.IsStudent == false && p.IsOther == true).ToListAsync().ConfigureAwait(false);
                return people;
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
                    person.IsOther = true;
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
                        IsOther = true,
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

        public OtherPeopleRepository(PeopleDbContext context)
            : base(context) { }
    }
}

