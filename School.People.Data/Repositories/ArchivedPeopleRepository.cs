using System;
using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using School.People.Core.Repositories;

namespace School.People.Data.Repositories
{
    public class ArchivedPeopleRepository : PeopleRepository, IArchivedPeopleRepository
    {
        public async Task<IEnumerable<IPerson>> ReadAllAsync()
        {
            try
            {
                IEnumerable<DbPerson> people = await Context.People.Where(p => p.IsPersonnel == false &&
                    p.IsStudent == false && p.IsOther == false).ToListAsync().ConfigureAwait(false);
                return people;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> ContainsAsync(IPerson item)
        {
            DbPerson person = await GetPersonByNameAsync(item).ConfigureAwait(false);
            return person != null;
        }

        public ArchivedPeopleRepository(PeopleDbContext context)
            : base(context) { }
    }
}
