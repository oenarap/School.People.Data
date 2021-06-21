using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbOtherInformation : DbEntityMultiple, IOtherInformation
    {
        [Required]
        [MaxLength(Lengths.OtherInformationCategoryMaxLength)]
        public string Category { get; set; }

        [Required]
        [MaxLength(Lengths.CommonNamesAndTitlesMaxLength)]
        public string DescriptiveName { get; set; }

        [MaxLength(Lengths.OtherInformationDetailsMaxLength)]
        public string Details { get; set; }
    }
}
