using System;
using School.People.Core;
using System.ComponentModel;

namespace School.People.Data
{
    public abstract class DbActivity : DbEntityMultiple, IActivity
    {
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        [DefaultValue(false)]
        public bool IsOngoing { get; set; }

        public Guid? LocationAddressId { get; set; }
    }
}
