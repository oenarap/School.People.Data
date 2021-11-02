using System;
using School.People.Core;
using System.ComponentModel;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbEducation : DbEntityMultiple, IEducation
    {
        [Required]
        [MaxLength(Constants.EducationLevelMaxLength)]
        public string Level { get; set; }

        [Required]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string SchoolName { get; set; }

        [Required]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string DegreeCourse { get; set; }

        [MaxLength(4)]
        public string IfGraduatedYearGraduated { get; set; }

        [MaxLength(Constants.HighestLevelOrUnitsEarnedMaxLength)]
        public string IfNotGraduatedHighestLevelOrUnitsEarned { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        [MaxLength(Constants.ScholarshipOrHonorsReceivedMaxLength)]
        public string ScholarshipOrHonorsReceived { get; set; }

        [DefaultValue(false)]
        public bool IsOngoing { get; set; }
    }
}
