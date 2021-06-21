using System;
using School.People.Core.Attributes;

namespace School.People.Data
{
    internal class DbFamilyIds : DbEntitySingle, IFamilyIds
    {
        public Guid? MotherId { get; set; }
        public Guid? FatherId { get; set; }
        public Guid? SpouseId { get; set; }
    }
}
