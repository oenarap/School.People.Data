using System;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal partial class DbDateOfBirth : DbEntitySingle, IDateOfBirth
    {
        [DataType("datetimeoffset(7)")]
        public DateTimeOffset? Birthdate { get; set; }
    }
}
