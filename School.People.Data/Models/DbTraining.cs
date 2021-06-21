using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbTraining : DbActivity, ITraining
    {
        [Required]
        [MaxLength(Lengths.CommonNamesAndTitlesMaxLength)]
        public string TitleOfTrainingProgram { get; set; }

        public double DurationHours { get; set; }

        [MaxLength(Lengths.CommonNamesAndTitlesMaxLength)]
        public string Sponsor { get; set; }
    }
}
