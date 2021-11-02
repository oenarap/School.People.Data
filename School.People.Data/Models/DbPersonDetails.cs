using School.People.Core;
using System.ComponentModel;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal partial class DbPersonDetails : DbEntitySingle, IPersonDetails
    {
        [MaxLength(Constants.SexMaxLength)]
        public string Sex { get; set; }

        [MaxLength(Constants.CivilStatusMaxLength)]
        public string CivilStatus { get; set; }

        [MaxLength(Constants.CivilStatusMaxLength)]
        public string OtherCivilStatus { get; set; }

        [DefaultValue(0d)]
        public double HeightInCentimeters { get; set; }

        [DefaultValue(0d)]
        public double WeightInKilograms { get; set; }

        [MaxLength(Constants.BloodTypeMaxLength)]
        public string BloodType { get; set; }
    }
}
