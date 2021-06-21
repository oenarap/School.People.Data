using System;
using School.People.Core.Attributes;

namespace School.People.Data
{
    internal class DbAddressIds : DbEntitySingle, IAddressIds
    {
        public Guid? BirthAddressId { get; set; }
        public Guid? ResidentialAddressId { get; set; }
        public Guid? PermanentAddressId { get; set; }
        public Guid? BusinessAddressId { get; set; }
        public Guid? CommunityTaxCertificateIssuanceAddressId { get; set; }
    }
}
