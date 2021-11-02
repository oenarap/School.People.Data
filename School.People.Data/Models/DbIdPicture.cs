using School.People.Core.Attributes;
using School.People.Core;

namespace School.People.Data
{
    internal class DbIdPicture : DbEntitySingle, IIdPicture
    {
        public byte[] RecentPhoto { get; set; }
    }
}
