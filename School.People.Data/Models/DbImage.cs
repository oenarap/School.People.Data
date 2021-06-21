using School.People.Core.Attributes;

namespace School.People.Data
{
    internal class DbImage : DbEntitySingle, IImage
    {
        public byte[] RecentPhoto { get; set; }
    }
}
