using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbCitizenship : DbEntitySingle, ICitizenship
    {
        [MaxLength(Lengths.DualCitizenshipModeMaxLength)]
        public string DualCitizenshipMode { get; set; }

        [MaxLength(Lengths.CitizenshipMaxLength)]
        public string DualCitizenship { get; set; }

        [MaxLength(Lengths.CitizenshipMaxLength)]
        public string Country { get; set; }
    }
}
