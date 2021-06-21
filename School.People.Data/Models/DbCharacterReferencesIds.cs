using System;
using School.People.Core.Attributes;

namespace School.People.Data
{
    internal class DbCharacterReferencesIds : DbEntitySingle, ICharacterReferencesIds
    {
        public Guid? ReferenceA { get; set; }
        public Guid? ReferenceB { get; set; }
        public Guid? ReferenceC { get; set; }
    }
}
