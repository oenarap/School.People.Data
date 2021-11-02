using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbCitizenship : DbEntitySingle, ICitizenship
    {
        [MaxLength(Constants.DualCitizenshipModeMaxLength)]
        public string DualCitizenshipMode { get; set; }

        [MaxLength(Constants.CitizenshipMaxLength)]
        public string DualCitizenship { get; set; }

        [MaxLength(Constants.CitizenshipMaxLength)]
        public string Country { get; set; }
    }
}
