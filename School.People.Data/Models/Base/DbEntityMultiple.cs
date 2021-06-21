using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.People.Data
{
    public class DbEntityMultiple : DbEntity
    {
        [Key]
        public Guid Index { get; set; }

        [Required]
        public Guid Id { get; set; }
    }
}
