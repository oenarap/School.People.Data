using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class CharacterReferencesIdsRepository : Repository<ICharacterReferencesIds, PeopleDbContext>, ICharacterReferencesIdsRepository
    {
        public async Task<ICharacterReferencesIds> ReadAsync(Guid id)
        {
            try
            {
                return await Context.CharacterReferencesIds.AsNoTracking()
                    .Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(ICharacterReferencesIds item)
        {
            try
            {
                var ids = await Context.CharacterReferencesIds.Where(i => i.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (ids != null)
                {
                    ids.ReferenceA = item.ReferenceA;
                    ids.ReferenceB = item.ReferenceB;
                    ids.ReferenceC = item.ReferenceC;
                    ids.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    ids = new DbCharacterReferencesIds()
                    {
                        Id = item.Id,
                        ReferenceB = item.ReferenceB,
                        ReferenceA = item.ReferenceA,
                        ReferenceC = item.ReferenceC,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.CharacterReferencesIds.AddAsync(ids);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public CharacterReferencesIdsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
