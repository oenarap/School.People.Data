using System;
using System.ComponentModel;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbEligibility : DbEntityMultiple, IEligibility
    {
        [Required]
        public string EligibilityName { get; set; }

        public double Rating { get; set; }

        public DateTimeOffset? DateOfExamOrConferment { get; set; }

        public Guid? PlaceOfExamConferment { get; set; }

        public string LicenseNumberIfApplicable { get; set; }

        public DateTimeOffset? LicenseDateOfRelease { get; set; }
    }
}
