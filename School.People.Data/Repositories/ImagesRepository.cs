using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class ImagesRepository : Repository<IIdPicture, PeopleDbContext>, IImagesRepository
    {
        public async Task<IIdPicture> ReadAsync(Guid id)
        {
            try
            {
                return await Context.Images.AsNoTracking()
                    .Where(i => i.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdateAsync(IIdPicture item)
        {
            try
            {
                var image = await Context.Images.Where(i => i.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                
                if (image != null)
                {
                    image.RecentPhoto = item.RecentPhoto;
                    image.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    image = new DbIdPicture()
                    {
                        Id = item.Id,
                        RecentPhoto = item.RecentPhoto,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Images.AddAsync(image);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ImagesRepository(PeopleDbContext context)
            : base(context) { }
    }
}
