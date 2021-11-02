using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbTraining : DbActivity, ITraining
    {
        [Required]
        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string TitleOfTrainingProgram { get; set; }

        public double DurationHours { get; set; }

        [MaxLength(Constants.CommonNamesAndTitlesMaxLength)]
        public string Sponsor { get; set; }
    }
}
