using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbAgencyMemberDetails : DbEntitySingle, IAgencyMemberDetails
    {
        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string AgencyId { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string GsisIdNumber { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string PagIbigIdNumber { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string PhilhealthNumber { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string SssNumber { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string Tin { get; set; }
    }
}
