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
                return await Context.People.AsNoTracking()
                    .Where(p => p.IsPersonnel == false &&
                    p.IsStudent == false && p.IsOther == false)
                    .ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        //public async Task<bool> ContainsAsync(IPerson item)
        //{
        //    var count = Context.People.Count(p => p.LastName == item.LastName
        //        && p.FirstName == item.FirstName && p.MiddleName == item.MiddleName
        //        && p.NameExtension == item.NameExtension);
        //    return count > 0;
        //}

        public ArchivedPeopleRepository(PeopleDbContext context)
            : base(context) { }
    }
}
