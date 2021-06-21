using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.People.Data
{
    public abstract class DbEntity
    {
        public DateTimeOffset? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTimeOffset? LastModifiedOn { get; set; }

        public Guid? LastModifiedBy { get; set; }
        
        //[Timestamp, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public byte[] Timestamp { get; set; }
    }
}
