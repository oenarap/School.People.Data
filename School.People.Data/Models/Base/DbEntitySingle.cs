using System;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    public abstract class DbEntitySingle : DbEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
