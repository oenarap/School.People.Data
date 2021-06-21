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

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string RelationshipToAuthorityDetails { get; set; }

        public bool IsGuiltyOfAdministrativeOffense { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string AdministrativeOffenseDetails { get; set; }

        public bool WasCriminallyCharged { get; set; }
        public DateTimeOffset? CriminalChargesFilingDate { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string CriminalChargesCaseStatus { get; set; }

        public bool WasConvicted { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string ConvictionDetails { get; set; }

        public bool WasSeparatedFromService { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string SeparationFromServiceDetails { get; set; }

        public bool WasNatlOrLocalElectionCandidate { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string NatlOrLocalElectionCandidacyDetails { get; set; }

        public bool HasResignedForCandidacy { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string ResignationForCandidacyDetails { get; set; }

        public bool HasAcquiredImmigrantStatus { get; set; }

        [MaxLength(Lengths.CitizenshipMaxLength)]
        public string OriginCountry { get; set; }

        public bool IsIndigenousGroupMember { get; set; }

        [MaxLength(Lengths.FaqsDetailsMaxLength)]
        public string IndigenousGroupMembershipDetails { get; set; }

        public bool IsDifferentlyAbled { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string DifferentlyAbledIdNumber { get; set; }

        public bool IsSoloParent { get; set; }

        [MaxLength(Lengths.IdNumbersMaxLength)]
        public string SoloParentIdNumber { get; set; }
    }
}
