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
                return await Context.People.AsNoTracking()
                    .Where(p => p.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public PersonRepository(PeopleDbContext context)
            : base(context) { }
    }
}
