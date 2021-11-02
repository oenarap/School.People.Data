using System;
using School.People.Core;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    public abstract class DbOccupation : DbActivity, IOccupation
    {
        [Required]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string PositionTitle { get; set; }

        [Required]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string EmployerOrganizationOrBusinessName { get; set; }

        [MaxLength(Constants.ContactNumbersMaxLength)]
        public string TelephoneNumber { get; set; }
    }
}
