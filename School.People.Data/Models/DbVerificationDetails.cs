using System;
using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbVerificationDetails : DbEntitySingle, IVerificationDetails
    {
        [MaxLength(Constants.IdNumbersMaxLength)]
        public string CommunityTaxCertificateNumber { get; set; }

        public DateTimeOffset? CommunityTaxCertificateIssuanceDate { get; set; }
    }
}
