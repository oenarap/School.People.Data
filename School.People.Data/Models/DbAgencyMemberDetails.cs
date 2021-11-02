using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbAgencyMemberDetails : DbEntitySingle, IAgencyMemberDetails
    {
        [MaxLength(Constants.IdNumbersMaxLength)]
        public string AgencyId { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string GsisIdNumber { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string PagIbigIdNumber { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string PhilhealthNumber { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string SssNumber { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string Tin { get; set; }
    }
}
