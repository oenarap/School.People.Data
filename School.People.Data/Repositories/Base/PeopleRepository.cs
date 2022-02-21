using System;
using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public abstract class PeopleRepository : Repository<IPerson, PeopleDbContext>
    {
        internal async Task<DbPerson> GetPersonByNameAsync(IPerson key)
        {
            var person = await Context.People.Where(p => p.LastName == key.LastName &&
                p.FirstName == key.FirstName && p.MiddleName == key.MiddleName)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            if (person != null && string.Equals(person.NameExtension, key.NameExtension, StringComparison.OrdinalIgnoreCase)) 
            { return person; }
            return null;
        }

        internal PeopleRepository(PeopleDbContext context)
            : base(context) { }
    }
}
