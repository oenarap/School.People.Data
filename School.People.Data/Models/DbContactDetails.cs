using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal partial class DbContactDetails : DbEntitySingle, IContactDetails
    {
        [MaxLength(Lengths.EmailAddressMaxLength)]
        public string EmailAddress { get; set; }

        [MaxLength(Lengths.ContactNumbersMaxLength)]
        public string TelephoneNumber { get; set; }

        [MaxLength(Lengths.ContactNumbersMaxLength)]
        public string MobileNumber { get; set; }
    }
}
