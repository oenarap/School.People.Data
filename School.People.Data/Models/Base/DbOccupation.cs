using System;
using School.People.Core;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    public abstract class DbOccupation : DbActivity, IOccupation
    {
        [Required]
        [MaxLength(Lengths.CommonNamesAndTitlesMaxLength)]
        public string PositionTitle { get; set; }

        [Required]
        [MaxLength(Lengths.CommonNamesAndTitlesMaxLength)]
        public string EmployerOrganizationOrBusinessName { get; set; }

        [MaxLength(Lengths.ContactNumbersMaxLength)]
        public string TelephoneNumber { get; set; }
    }
}
