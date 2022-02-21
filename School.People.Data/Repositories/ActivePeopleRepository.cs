using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace School.People.Data.Repositories
{
    public class ActivePeopleRepository : PeopleRepository, IActivePeopleRepository
    {
        /// <summary>
        /// Updates an existing <see cref="IPerson"/> in the repository.
        /// </summary>
        /// <returns>A <see cref="bool"/> indicating whether the operation is successful or not.</returns>
        public virtual async Task<bool> UpdateAsync(IPerson item)
        {
            try
            {
                var person = await GetPersonByNameAsync(item).ConfigureAwait(false);
                if (person == null)
                {
                    person = await Context.People.Where(p => p.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (person != null)
                    {
                        person.LastName = item.LastName;
                        person.FirstName = item.FirstName;
                        person.MiddleName = item.MiddleName;
                        person.NameExtension = item.NameExtension;
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

        public ActivePeopleRepository(PeopleDbContext context)
            : base(context) { }
    }
}
