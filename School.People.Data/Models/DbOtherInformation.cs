using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbOtherInformation : DbEntityMultiple, IOtherInformation
    {
        [Required]
        [MaxLength(Constants.OtherInformationCategoryMaxLength)]
        public string Category { get; set; }

        [Required]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string DescriptiveName { get; set; }

        [MaxLength(Constants.OtherInformationDetailsMaxLength)]
        public string Details { get; set; }
    }
}
