using System;
using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class PersonRepository : Repository<IPerson, PeopleDbContext>, IPersonRepository
    {
        public async Task<IPerson> ReadAsync(Guid id)
        {
            try
            {
                var person = await Context.People.Where(p => p.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return person;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public PersonRepository(PeopleDbContext context)
            : base(context) { }
    }
}
