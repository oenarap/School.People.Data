using School.People.Core;
using System.ComponentModel;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal partial class DbPersonDetails : DbEntitySingle, IPersonDetails
    {
        [MaxLength(Lengths.SexMaxLength)]
        public string Sex { get; set; }

        [MaxLength(Lengths.CivilStatusMaxLength)]
        public string CivilStatus { get; set; }

        [MaxLength(Lengths.CivilStatusMaxLength)]
        public string OtherCivilStatus { get; set; }

        [DefaultValue(0d)]
        public double HeightInCentimeters { get; set; }

        [DefaultValue(0d)]
        public double WeightInKilograms { get; set; }

        [MaxLength(Lengths.BloodTypeMaxLength)]
        public string BloodType { get; set; }
    }
}
