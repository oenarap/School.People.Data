using System;
using School.People.Core;
using School.People.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace School.People.Data
{
    internal class DbFaqs : DbEntitySingle, IFaqs
    {
        public bool IsRelatedToAuthorityThirdDegree { get; set; }
        public bool IsRelatedToAuthorityFourthDegree { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string RelationshipToAuthorityDetails { get; set; }

        public bool IsGuiltyOfAdministrativeOffense { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string AdministrativeOffenseDetails { get; set; }

        public bool WasCriminallyCharged { get; set; }
        public DateTimeOffset? CriminalChargesFilingDate { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string CriminalChargesCaseStatus { get; set; }

        public bool WasConvicted { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string ConvictionDetails { get; set; }

        public bool WasSeparatedFromService { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string SeparationFromServiceDetails { get; set; }

        public bool WasNatlOrLocalElectionCandidate { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string NatlOrLocalElectionCandidacyDetails { get; set; }

        public bool HasResignedForCandidacy { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string ResignationForCandidacyDetails { get; set; }

        public bool HasAcquiredImmigrantStatus { get; set; }

        [MaxLength(Constants.CitizenshipMaxLength)]
        public string OriginCountry { get; set; }

        public bool IsIndigenousGroupMember { get; set; }

        [MaxLength(Constants.FaqsDetailsMaxLength)]
        public string IndigenousGroupMembershipDetails { get; set; }

        public bool IsDifferentlyAbled { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string DifferentlyAbledIdNumber { get; set; }

        public bool IsSoloParent { get; set; }

        [MaxLength(Constants.IdNumbersMaxLength)]
        public string SoloParentIdNumber { get; set; }
    }
}
